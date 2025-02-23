from antlr4 import *
from SVLexer import SVLexer
from SVParser import SVParser
from SVListener import SVListener
import antlr4
import json
from marco import MARCOS
import copy
from database import COMMANDS
def load_text(fp):
    with open(fp,encoding='utf-8') as f:
        data = f.read()
    return data

def parse_string(input_text):
    lexer = SVLexer(InputStream(input_text)) 
    stream = CommonTokenStream(lexer)
    parser = SVParser(stream)
    tree = parser.prog()
    str_tree = tree.toStringTree(recog=parser)
    return tree,str_tree

def filter_null(lst):
    return list([x for x in lst if x is not None])
def parse_file(fp):
    text = load_text(fp)
    tree = parse_string(text)
    return tree

def get_function_args(function_key):
    if function_key in COMMANDS:
        return copy.deepcopy(COMMANDS[function_key])
    return {}

def list_kwargs(lst,function_key):
    has_dict = any(isinstance(item, dict) for item in lst)
    only_dict = all(isinstance(item, dict) for item in lst)
    payload = get_function_args((function_key))
    args = []
    kwargs = []
    for item in lst:
        if isinstance(item, dict):
            kwargs.append(item)
        else:
            args.append(item)
    # f
    # if has_dict and not only_dict:
    #     raise AssertionError("Do not support mixing-")
    # elif only_dict:
    #     for kwarg in lst:
    #         payload.update(kwarg)
    #     return payload
    # else:
    
    keys = list(payload.keys())
    for i,v in enumerate(args):
            if i < len(keys):
                payload[keys[i]] = v

    for kv in kwargs:
        payload.update(kv)
    all_kwargs = {}
    for kv in kwargs:
        all_kwargs.update(kv)
    return payload,args,all_kwargs


class ScriptResolver:

    def __init__(self) -> None:
        self.id = 0

    def get_increment_id(self):
        curr_id = self.id
        self.id += 1
        return curr_id

    def build_tree(self,context):
        # try:
        #     print(context.getText())
        # except:
        #     print("Terminal!")
        if isinstance(context,SVParser.ProgContext):
            return filter_null([self.build_tree(x) for x in  context.expr()])
        if isinstance(context,SVParser.ExprContext):
            if l:= context.function_call():
                return self.build_tree(l)
            elif l:= context.parallel_bock():
                return self.build_tree(l)
            elif l:= context.if_block():
                return self.build_tree(l)
            elif l:= context.parallel_bock_arg():
                return self.build_tree(l)
            elif l:= context.sequential_block():
                return self.build_tree(l)
            else:
                raise NotImplementedError
        elif isinstance(context,SVParser.Function_callContext):
            function_name = self.build_tree(context.function_name())
            payload = {
                "CommandType":function_name,
                "Identifier":self.get_increment_id()
            }
            if children:=context.arguments():
                parsed_children = filter_null([self.build_tree(x) for x in  children.argument() ])
                payload['Parameters'],args,kwargs = list_kwargs(parsed_children,function_name)
            else:
                args = []
                kwargs = {}
            if function_name.replace('.','__') in MARCOS.is_marco:
                # print("Applying Marcos---",function_name)
                new_payload = MARCOS.registry[function_name.replace('.','__')](*args,**kwargs)
                
                new_payload["Identifier"] = payload["Identifier"]
                payload = new_payload
            return payload
        elif isinstance(context,SVParser.ArgumentContext):
            if l:= context.positional_argument():
                return self.build_tree(l)
            elif l:= context.keyword_argument():
                return self.build_tree(l)
            else:
                raise NotImplementedError
        elif isinstance(context,SVParser.Positional_argumentContext):
            return self.build_tree(context.literal())
        elif isinstance(context,SVParser.Keyword_argumentContext):
            return {self.build_tree(context.IDENTIFIER()):self.build_tree(context.literal())}
        elif isinstance(context,SVParser.Function_nameContext):
            return self.build_tree(context.IDENTIFIER())
        elif isinstance(context,SVParser.Parallel_bockContext):
            payload = {
                "CommandType":"ParallelCommand",
                "Identifier":self.get_increment_id(),
                "Parameters": {
                    "subcommands": list(
                        self.build_tree(x) for x in context.parallel_bock_arg()
                    )
                }
            }
            return payload
        elif isinstance(context,SVParser.Sequential_blockContext):
            subcommands =  context.prog().expr()
            if subcommands:
                payload = {
                    "CommandType":"SequentialCommand",
                    "Identifier":self.get_increment_id(),
                    "Parameters": {
                        "subcommands": [self.build_tree(x) for x in subcommands]
                    }
                }
            else:
                payload = {
                    "CommandType":"NOOP",
                    "Identifier":self.get_increment_id(),
                    "Parameters": {
                    }
                }
            return payload
        elif isinstance(context,SVParser.Parallel_bock_argContext):
            time_signature = context.time_singature()
            delay = time_signature.INTEGER_LITERAL() or time_signature.FLOAT_LITERAL()
            delay = float(delay.symbol.text)
            command = self.build_tree(context.expr())
            if delay == 0:
                return command
            else:            
                payload = {
                    "CommandType":"DelayedExecution",
                    "Identifier":self.get_increment_id(),
                    "Parameters": {
                        "duration":delay,
                        "command":command
                    }
                }
                return payload
        elif isinstance(context,SVParser.LiteralContext):
            literal = context.STRING_LITERAL() or context.INTEGER_LITERAL() or context.FLOAT_LITERAL() \
                or context.BOOLEAN_LITERAL()
            return self.build_tree(literal)
        elif isinstance(context,antlr4.tree.Tree.TerminalNodeImpl):
            if context.symbol.type == SVParser.IDENTIFIER:
                return context.symbol.text
            elif context.symbol.type == SVParser.STRING_LITERAL:
                return context.symbol.text[1:-1]
            elif context.symbol.type == SVParser.INTEGER_LITERAL:
                return int(context.symbol.text)
            elif context.symbol.type == SVParser.FLOAT_LITERAL:
                return float(context.symbol.text)
            elif context.symbol.type == SVParser.BOOLEAN_LITERAL:
                if context.symbol.text == 'true':
                    return True
                elif context.symbol.text == 'false':
                    return False
                else:
                    raise NotImplementedError(context.symbol.text)
            else:
                raise NotImplementedError(context.symbol.text)
        elif isinstance(context,SVParser.If_blockContext):
            cond_expr = context.cond_expr()
            key = self.build_tree(cond_expr.IDENTIFIER())
            value = self.build_tree(cond_expr.BOOLEAN_LITERAL())
            subcommands = self.build_tree(context.prog())
            payload = {
                    "CommandType":"ConditionalExecution",
                    "Identifier":self.get_increment_id(),
                    "Parameters": {
                        "key":key,
                        "value":value,
                        "command":{
                            "CommandType":"SequentialCommand",
                            "Identifier":self.get_increment_id(),
                            "Parameters": {
                                "subcommands": subcommands
                            }
                        }
                    }
            }
            return payload
        else:
            raise NotImplementedError(context.getText())
            #return context

if __name__ == '__main__':

    tree,str_tree = parse_file('testcase.csx')
    tree_parsed = ScriptResolver().build_tree(tree)
    print(tree_parsed)
    json.dumps(tree_parsed)
    