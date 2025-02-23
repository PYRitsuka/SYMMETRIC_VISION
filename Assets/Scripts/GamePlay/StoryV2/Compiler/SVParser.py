# Generated from SV.g4 by ANTLR 4.13.1
# encoding: utf-8
from antlr4 import *
from io import StringIO
import sys
if sys.version_info[1] > 5:
	from typing import TextIO
else:
	from typing.io import TextIO

def serializedATN():
    return [
        4,1,18,110,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
        6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,
        2,14,7,14,1,0,1,0,1,1,1,1,1,1,3,1,36,8,1,1,1,3,1,39,8,1,1,1,1,1,
        1,1,1,2,1,2,1,3,1,3,1,3,5,3,49,8,3,10,3,12,3,52,9,3,1,4,1,4,3,4,
        56,8,4,1,5,1,5,1,6,1,6,1,6,1,6,1,7,1,7,1,7,5,7,67,8,7,10,7,12,7,
        70,9,7,1,7,1,7,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,10,1,10,1,10,1,10,1,
        10,1,10,1,10,1,10,1,11,1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,13,1,
        13,1,13,1,13,1,13,3,13,102,8,13,1,14,5,14,105,8,14,10,14,12,14,108,
        9,14,1,14,0,0,15,0,2,4,6,8,10,12,14,16,18,20,22,24,26,28,0,2,1,0,
        14,17,1,0,16,17,104,0,30,1,0,0,0,2,32,1,0,0,0,4,43,1,0,0,0,6,45,
        1,0,0,0,8,55,1,0,0,0,10,57,1,0,0,0,12,59,1,0,0,0,14,63,1,0,0,0,16,
        73,1,0,0,0,18,76,1,0,0,0,20,80,1,0,0,0,22,88,1,0,0,0,24,92,1,0,0,
        0,26,101,1,0,0,0,28,106,1,0,0,0,30,31,7,0,0,0,31,1,1,0,0,0,32,33,
        3,4,2,0,33,35,5,1,0,0,34,36,3,6,3,0,35,34,1,0,0,0,35,36,1,0,0,0,
        36,38,1,0,0,0,37,39,5,2,0,0,38,37,1,0,0,0,38,39,1,0,0,0,39,40,1,
        0,0,0,40,41,5,3,0,0,41,42,5,4,0,0,42,3,1,0,0,0,43,44,5,18,0,0,44,
        5,1,0,0,0,45,50,3,8,4,0,46,47,5,2,0,0,47,49,3,8,4,0,48,46,1,0,0,
        0,49,52,1,0,0,0,50,48,1,0,0,0,50,51,1,0,0,0,51,7,1,0,0,0,52,50,1,
        0,0,0,53,56,3,10,5,0,54,56,3,12,6,0,55,53,1,0,0,0,55,54,1,0,0,0,
        56,9,1,0,0,0,57,58,3,0,0,0,58,11,1,0,0,0,59,60,5,18,0,0,60,61,5,
        5,0,0,61,62,3,0,0,0,62,13,1,0,0,0,63,64,5,11,0,0,64,68,5,6,0,0,65,
        67,3,18,9,0,66,65,1,0,0,0,67,70,1,0,0,0,68,66,1,0,0,0,68,69,1,0,
        0,0,69,71,1,0,0,0,70,68,1,0,0,0,71,72,5,7,0,0,72,15,1,0,0,0,73,74,
        5,12,0,0,74,75,7,1,0,0,75,17,1,0,0,0,76,77,3,16,8,0,77,78,5,2,0,
        0,78,79,3,26,13,0,79,19,1,0,0,0,80,81,5,13,0,0,81,82,5,1,0,0,82,
        83,3,22,11,0,83,84,5,3,0,0,84,85,5,6,0,0,85,86,3,28,14,0,86,87,5,
        7,0,0,87,21,1,0,0,0,88,89,5,18,0,0,89,90,5,8,0,0,90,91,5,14,0,0,
        91,23,1,0,0,0,92,93,5,6,0,0,93,94,3,28,14,0,94,95,5,7,0,0,95,25,
        1,0,0,0,96,102,3,2,1,0,97,102,3,14,7,0,98,102,3,20,10,0,99,102,3,
        18,9,0,100,102,3,24,12,0,101,96,1,0,0,0,101,97,1,0,0,0,101,98,1,
        0,0,0,101,99,1,0,0,0,101,100,1,0,0,0,102,27,1,0,0,0,103,105,3,26,
        13,0,104,103,1,0,0,0,105,108,1,0,0,0,106,104,1,0,0,0,106,107,1,0,
        0,0,107,29,1,0,0,0,108,106,1,0,0,0,7,35,38,50,55,68,101,106
    ]

class SVParser ( Parser ):

    grammarFileName = "SV.g4"

    atn = ATNDeserializer().deserialize(serializedATN())

    decisionsToDFA = [ DFA(ds, i) for i, ds in enumerate(atn.decisionToState) ]

    sharedContextCache = PredictionContextCache()

    literalNames = [ "<INVALID>", "'('", "','", "')'", "';'", "'='", "'{'", 
                     "'}'", "'=='", "<INVALID>", "<INVALID>", "'cmd_block'", 
                     "'at'", "'if'" ]

    symbolicNames = [ "<INVALID>", "<INVALID>", "<INVALID>", "<INVALID>", 
                      "<INVALID>", "<INVALID>", "<INVALID>", "<INVALID>", 
                      "<INVALID>", "LINE_COMMENT", "WS", "CMD_BLOCK", "AT", 
                      "IF", "BOOLEAN_LITERAL", "STRING_LITERAL", "INTEGER_LITERAL", 
                      "FLOAT_LITERAL", "IDENTIFIER" ]

    RULE_literal = 0
    RULE_function_call = 1
    RULE_function_name = 2
    RULE_arguments = 3
    RULE_argument = 4
    RULE_positional_argument = 5
    RULE_keyword_argument = 6
    RULE_parallel_bock = 7
    RULE_time_singature = 8
    RULE_parallel_bock_arg = 9
    RULE_if_block = 10
    RULE_cond_expr = 11
    RULE_sequential_block = 12
    RULE_expr = 13
    RULE_prog = 14

    ruleNames =  [ "literal", "function_call", "function_name", "arguments", 
                   "argument", "positional_argument", "keyword_argument", 
                   "parallel_bock", "time_singature", "parallel_bock_arg", 
                   "if_block", "cond_expr", "sequential_block", "expr", 
                   "prog" ]

    EOF = Token.EOF
    T__0=1
    T__1=2
    T__2=3
    T__3=4
    T__4=5
    T__5=6
    T__6=7
    T__7=8
    LINE_COMMENT=9
    WS=10
    CMD_BLOCK=11
    AT=12
    IF=13
    BOOLEAN_LITERAL=14
    STRING_LITERAL=15
    INTEGER_LITERAL=16
    FLOAT_LITERAL=17
    IDENTIFIER=18

    def __init__(self, input:TokenStream, output:TextIO = sys.stdout):
        super().__init__(input, output)
        self.checkVersion("4.13.1")
        self._interp = ParserATNSimulator(self, self.atn, self.decisionsToDFA, self.sharedContextCache)
        self._predicates = None




    class LiteralContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def STRING_LITERAL(self):
            return self.getToken(SVParser.STRING_LITERAL, 0)

        def INTEGER_LITERAL(self):
            return self.getToken(SVParser.INTEGER_LITERAL, 0)

        def FLOAT_LITERAL(self):
            return self.getToken(SVParser.FLOAT_LITERAL, 0)

        def BOOLEAN_LITERAL(self):
            return self.getToken(SVParser.BOOLEAN_LITERAL, 0)

        def getRuleIndex(self):
            return SVParser.RULE_literal

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterLiteral" ):
                listener.enterLiteral(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitLiteral" ):
                listener.exitLiteral(self)




    def literal(self):

        localctx = SVParser.LiteralContext(self, self._ctx, self.state)
        self.enterRule(localctx, 0, self.RULE_literal)
        self._la = 0 # Token type
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 30
            _la = self._input.LA(1)
            if not((((_la) & ~0x3f) == 0 and ((1 << _la) & 245760) != 0)):
                self._errHandler.recoverInline(self)
            else:
                self._errHandler.reportMatch(self)
                self.consume()
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class Function_callContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def function_name(self):
            return self.getTypedRuleContext(SVParser.Function_nameContext,0)


        def arguments(self):
            return self.getTypedRuleContext(SVParser.ArgumentsContext,0)


        def getRuleIndex(self):
            return SVParser.RULE_function_call

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterFunction_call" ):
                listener.enterFunction_call(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitFunction_call" ):
                listener.exitFunction_call(self)




    def function_call(self):

        localctx = SVParser.Function_callContext(self, self._ctx, self.state)
        self.enterRule(localctx, 2, self.RULE_function_call)
        self._la = 0 # Token type
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 32
            self.function_name()
            self.state = 33
            self.match(SVParser.T__0)
            self.state = 35
            self._errHandler.sync(self)
            _la = self._input.LA(1)
            if (((_la) & ~0x3f) == 0 and ((1 << _la) & 507904) != 0):
                self.state = 34
                self.arguments()


            self.state = 38
            self._errHandler.sync(self)
            _la = self._input.LA(1)
            if _la==2:
                self.state = 37
                self.match(SVParser.T__1)


            self.state = 40
            self.match(SVParser.T__2)
            self.state = 41
            self.match(SVParser.T__3)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class Function_nameContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def IDENTIFIER(self):
            return self.getToken(SVParser.IDENTIFIER, 0)

        def getRuleIndex(self):
            return SVParser.RULE_function_name

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterFunction_name" ):
                listener.enterFunction_name(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitFunction_name" ):
                listener.exitFunction_name(self)




    def function_name(self):

        localctx = SVParser.Function_nameContext(self, self._ctx, self.state)
        self.enterRule(localctx, 4, self.RULE_function_name)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 43
            self.match(SVParser.IDENTIFIER)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class ArgumentsContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def argument(self, i:int=None):
            if i is None:
                return self.getTypedRuleContexts(SVParser.ArgumentContext)
            else:
                return self.getTypedRuleContext(SVParser.ArgumentContext,i)


        def getRuleIndex(self):
            return SVParser.RULE_arguments

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterArguments" ):
                listener.enterArguments(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitArguments" ):
                listener.exitArguments(self)




    def arguments(self):

        localctx = SVParser.ArgumentsContext(self, self._ctx, self.state)
        self.enterRule(localctx, 6, self.RULE_arguments)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 45
            self.argument()
            self.state = 50
            self._errHandler.sync(self)
            _alt = self._interp.adaptivePredict(self._input,2,self._ctx)
            while _alt!=2 and _alt!=ATN.INVALID_ALT_NUMBER:
                if _alt==1:
                    self.state = 46
                    self.match(SVParser.T__1)
                    self.state = 47
                    self.argument() 
                self.state = 52
                self._errHandler.sync(self)
                _alt = self._interp.adaptivePredict(self._input,2,self._ctx)

        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class ArgumentContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def positional_argument(self):
            return self.getTypedRuleContext(SVParser.Positional_argumentContext,0)


        def keyword_argument(self):
            return self.getTypedRuleContext(SVParser.Keyword_argumentContext,0)


        def getRuleIndex(self):
            return SVParser.RULE_argument

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterArgument" ):
                listener.enterArgument(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitArgument" ):
                listener.exitArgument(self)




    def argument(self):

        localctx = SVParser.ArgumentContext(self, self._ctx, self.state)
        self.enterRule(localctx, 8, self.RULE_argument)
        try:
            self.state = 55
            self._errHandler.sync(self)
            token = self._input.LA(1)
            if token in [14, 15, 16, 17]:
                self.enterOuterAlt(localctx, 1)
                self.state = 53
                self.positional_argument()
                pass
            elif token in [18]:
                self.enterOuterAlt(localctx, 2)
                self.state = 54
                self.keyword_argument()
                pass
            else:
                raise NoViableAltException(self)

        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class Positional_argumentContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def literal(self):
            return self.getTypedRuleContext(SVParser.LiteralContext,0)


        def getRuleIndex(self):
            return SVParser.RULE_positional_argument

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterPositional_argument" ):
                listener.enterPositional_argument(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitPositional_argument" ):
                listener.exitPositional_argument(self)




    def positional_argument(self):

        localctx = SVParser.Positional_argumentContext(self, self._ctx, self.state)
        self.enterRule(localctx, 10, self.RULE_positional_argument)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 57
            self.literal()
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class Keyword_argumentContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def IDENTIFIER(self):
            return self.getToken(SVParser.IDENTIFIER, 0)

        def literal(self):
            return self.getTypedRuleContext(SVParser.LiteralContext,0)


        def getRuleIndex(self):
            return SVParser.RULE_keyword_argument

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterKeyword_argument" ):
                listener.enterKeyword_argument(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitKeyword_argument" ):
                listener.exitKeyword_argument(self)




    def keyword_argument(self):

        localctx = SVParser.Keyword_argumentContext(self, self._ctx, self.state)
        self.enterRule(localctx, 12, self.RULE_keyword_argument)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 59
            self.match(SVParser.IDENTIFIER)
            self.state = 60
            self.match(SVParser.T__4)
            self.state = 61
            self.literal()
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class Parallel_bockContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def CMD_BLOCK(self):
            return self.getToken(SVParser.CMD_BLOCK, 0)

        def parallel_bock_arg(self, i:int=None):
            if i is None:
                return self.getTypedRuleContexts(SVParser.Parallel_bock_argContext)
            else:
                return self.getTypedRuleContext(SVParser.Parallel_bock_argContext,i)


        def getRuleIndex(self):
            return SVParser.RULE_parallel_bock

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterParallel_bock" ):
                listener.enterParallel_bock(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitParallel_bock" ):
                listener.exitParallel_bock(self)




    def parallel_bock(self):

        localctx = SVParser.Parallel_bockContext(self, self._ctx, self.state)
        self.enterRule(localctx, 14, self.RULE_parallel_bock)
        self._la = 0 # Token type
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 63
            self.match(SVParser.CMD_BLOCK)
            self.state = 64
            self.match(SVParser.T__5)
            self.state = 68
            self._errHandler.sync(self)
            _la = self._input.LA(1)
            while _la==12:
                self.state = 65
                self.parallel_bock_arg()
                self.state = 70
                self._errHandler.sync(self)
                _la = self._input.LA(1)

            self.state = 71
            self.match(SVParser.T__6)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class Time_singatureContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def AT(self):
            return self.getToken(SVParser.AT, 0)

        def INTEGER_LITERAL(self):
            return self.getToken(SVParser.INTEGER_LITERAL, 0)

        def FLOAT_LITERAL(self):
            return self.getToken(SVParser.FLOAT_LITERAL, 0)

        def getRuleIndex(self):
            return SVParser.RULE_time_singature

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterTime_singature" ):
                listener.enterTime_singature(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitTime_singature" ):
                listener.exitTime_singature(self)




    def time_singature(self):

        localctx = SVParser.Time_singatureContext(self, self._ctx, self.state)
        self.enterRule(localctx, 16, self.RULE_time_singature)
        self._la = 0 # Token type
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 73
            self.match(SVParser.AT)
            self.state = 74
            _la = self._input.LA(1)
            if not(_la==16 or _la==17):
                self._errHandler.recoverInline(self)
            else:
                self._errHandler.reportMatch(self)
                self.consume()
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class Parallel_bock_argContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def time_singature(self):
            return self.getTypedRuleContext(SVParser.Time_singatureContext,0)


        def expr(self):
            return self.getTypedRuleContext(SVParser.ExprContext,0)


        def getRuleIndex(self):
            return SVParser.RULE_parallel_bock_arg

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterParallel_bock_arg" ):
                listener.enterParallel_bock_arg(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitParallel_bock_arg" ):
                listener.exitParallel_bock_arg(self)




    def parallel_bock_arg(self):

        localctx = SVParser.Parallel_bock_argContext(self, self._ctx, self.state)
        self.enterRule(localctx, 18, self.RULE_parallel_bock_arg)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 76
            self.time_singature()
            self.state = 77
            self.match(SVParser.T__1)
            self.state = 78
            self.expr()
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class If_blockContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def IF(self):
            return self.getToken(SVParser.IF, 0)

        def cond_expr(self):
            return self.getTypedRuleContext(SVParser.Cond_exprContext,0)


        def prog(self):
            return self.getTypedRuleContext(SVParser.ProgContext,0)


        def getRuleIndex(self):
            return SVParser.RULE_if_block

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterIf_block" ):
                listener.enterIf_block(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitIf_block" ):
                listener.exitIf_block(self)




    def if_block(self):

        localctx = SVParser.If_blockContext(self, self._ctx, self.state)
        self.enterRule(localctx, 20, self.RULE_if_block)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 80
            self.match(SVParser.IF)
            self.state = 81
            self.match(SVParser.T__0)
            self.state = 82
            self.cond_expr()
            self.state = 83
            self.match(SVParser.T__2)
            self.state = 84
            self.match(SVParser.T__5)
            self.state = 85
            self.prog()
            self.state = 86
            self.match(SVParser.T__6)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class Cond_exprContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def IDENTIFIER(self):
            return self.getToken(SVParser.IDENTIFIER, 0)

        def BOOLEAN_LITERAL(self):
            return self.getToken(SVParser.BOOLEAN_LITERAL, 0)

        def getRuleIndex(self):
            return SVParser.RULE_cond_expr

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterCond_expr" ):
                listener.enterCond_expr(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitCond_expr" ):
                listener.exitCond_expr(self)




    def cond_expr(self):

        localctx = SVParser.Cond_exprContext(self, self._ctx, self.state)
        self.enterRule(localctx, 22, self.RULE_cond_expr)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 88
            self.match(SVParser.IDENTIFIER)
            self.state = 89
            self.match(SVParser.T__7)
            self.state = 90
            self.match(SVParser.BOOLEAN_LITERAL)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class Sequential_blockContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def prog(self):
            return self.getTypedRuleContext(SVParser.ProgContext,0)


        def getRuleIndex(self):
            return SVParser.RULE_sequential_block

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterSequential_block" ):
                listener.enterSequential_block(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitSequential_block" ):
                listener.exitSequential_block(self)




    def sequential_block(self):

        localctx = SVParser.Sequential_blockContext(self, self._ctx, self.state)
        self.enterRule(localctx, 24, self.RULE_sequential_block)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 92
            self.match(SVParser.T__5)
            self.state = 93
            self.prog()
            self.state = 94
            self.match(SVParser.T__6)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class ExprContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def function_call(self):
            return self.getTypedRuleContext(SVParser.Function_callContext,0)


        def parallel_bock(self):
            return self.getTypedRuleContext(SVParser.Parallel_bockContext,0)


        def if_block(self):
            return self.getTypedRuleContext(SVParser.If_blockContext,0)


        def parallel_bock_arg(self):
            return self.getTypedRuleContext(SVParser.Parallel_bock_argContext,0)


        def sequential_block(self):
            return self.getTypedRuleContext(SVParser.Sequential_blockContext,0)


        def getRuleIndex(self):
            return SVParser.RULE_expr

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterExpr" ):
                listener.enterExpr(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitExpr" ):
                listener.exitExpr(self)




    def expr(self):

        localctx = SVParser.ExprContext(self, self._ctx, self.state)
        self.enterRule(localctx, 26, self.RULE_expr)
        try:
            self.state = 101
            self._errHandler.sync(self)
            token = self._input.LA(1)
            if token in [18]:
                self.enterOuterAlt(localctx, 1)
                self.state = 96
                self.function_call()
                pass
            elif token in [11]:
                self.enterOuterAlt(localctx, 2)
                self.state = 97
                self.parallel_bock()
                pass
            elif token in [13]:
                self.enterOuterAlt(localctx, 3)
                self.state = 98
                self.if_block()
                pass
            elif token in [12]:
                self.enterOuterAlt(localctx, 4)
                self.state = 99
                self.parallel_bock_arg()
                pass
            elif token in [6]:
                self.enterOuterAlt(localctx, 5)
                self.state = 100
                self.sequential_block()
                pass
            else:
                raise NoViableAltException(self)

        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class ProgContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def expr(self, i:int=None):
            if i is None:
                return self.getTypedRuleContexts(SVParser.ExprContext)
            else:
                return self.getTypedRuleContext(SVParser.ExprContext,i)


        def getRuleIndex(self):
            return SVParser.RULE_prog

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterProg" ):
                listener.enterProg(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitProg" ):
                listener.exitProg(self)




    def prog(self):

        localctx = SVParser.ProgContext(self, self._ctx, self.state)
        self.enterRule(localctx, 28, self.RULE_prog)
        self._la = 0 # Token type
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 106
            self._errHandler.sync(self)
            _la = self._input.LA(1)
            while (((_la) & ~0x3f) == 0 and ((1 << _la) & 276544) != 0):
                self.state = 103
                self.expr()
                self.state = 108
                self._errHandler.sync(self)
                _la = self._input.LA(1)

        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx





