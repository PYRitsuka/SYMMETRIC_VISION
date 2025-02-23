# Generated from SV.g4 by ANTLR 4.13.1
from antlr4 import *
if "." in __name__:
    from .SVParser import SVParser
else:
    from SVParser import SVParser

# This class defines a complete listener for a parse tree produced by SVParser.
class SVListener(ParseTreeListener):

    # Enter a parse tree produced by SVParser#literal.
    def enterLiteral(self, ctx:SVParser.LiteralContext):
        pass

    # Exit a parse tree produced by SVParser#literal.
    def exitLiteral(self, ctx:SVParser.LiteralContext):
        pass


    # Enter a parse tree produced by SVParser#function_call.
    def enterFunction_call(self, ctx:SVParser.Function_callContext):
        pass

    # Exit a parse tree produced by SVParser#function_call.
    def exitFunction_call(self, ctx:SVParser.Function_callContext):
        pass


    # Enter a parse tree produced by SVParser#function_name.
    def enterFunction_name(self, ctx:SVParser.Function_nameContext):
        pass

    # Exit a parse tree produced by SVParser#function_name.
    def exitFunction_name(self, ctx:SVParser.Function_nameContext):
        pass


    # Enter a parse tree produced by SVParser#arguments.
    def enterArguments(self, ctx:SVParser.ArgumentsContext):
        pass

    # Exit a parse tree produced by SVParser#arguments.
    def exitArguments(self, ctx:SVParser.ArgumentsContext):
        pass


    # Enter a parse tree produced by SVParser#argument.
    def enterArgument(self, ctx:SVParser.ArgumentContext):
        pass

    # Exit a parse tree produced by SVParser#argument.
    def exitArgument(self, ctx:SVParser.ArgumentContext):
        pass


    # Enter a parse tree produced by SVParser#positional_argument.
    def enterPositional_argument(self, ctx:SVParser.Positional_argumentContext):
        pass

    # Exit a parse tree produced by SVParser#positional_argument.
    def exitPositional_argument(self, ctx:SVParser.Positional_argumentContext):
        pass


    # Enter a parse tree produced by SVParser#keyword_argument.
    def enterKeyword_argument(self, ctx:SVParser.Keyword_argumentContext):
        pass

    # Exit a parse tree produced by SVParser#keyword_argument.
    def exitKeyword_argument(self, ctx:SVParser.Keyword_argumentContext):
        pass


    # Enter a parse tree produced by SVParser#parallel_bock.
    def enterParallel_bock(self, ctx:SVParser.Parallel_bockContext):
        pass

    # Exit a parse tree produced by SVParser#parallel_bock.
    def exitParallel_bock(self, ctx:SVParser.Parallel_bockContext):
        pass


    # Enter a parse tree produced by SVParser#time_singature.
    def enterTime_singature(self, ctx:SVParser.Time_singatureContext):
        pass

    # Exit a parse tree produced by SVParser#time_singature.
    def exitTime_singature(self, ctx:SVParser.Time_singatureContext):
        pass


    # Enter a parse tree produced by SVParser#parallel_bock_arg.
    def enterParallel_bock_arg(self, ctx:SVParser.Parallel_bock_argContext):
        pass

    # Exit a parse tree produced by SVParser#parallel_bock_arg.
    def exitParallel_bock_arg(self, ctx:SVParser.Parallel_bock_argContext):
        pass


    # Enter a parse tree produced by SVParser#if_block.
    def enterIf_block(self, ctx:SVParser.If_blockContext):
        pass

    # Exit a parse tree produced by SVParser#if_block.
    def exitIf_block(self, ctx:SVParser.If_blockContext):
        pass


    # Enter a parse tree produced by SVParser#cond_expr.
    def enterCond_expr(self, ctx:SVParser.Cond_exprContext):
        pass

    # Exit a parse tree produced by SVParser#cond_expr.
    def exitCond_expr(self, ctx:SVParser.Cond_exprContext):
        pass


    # Enter a parse tree produced by SVParser#sequential_block.
    def enterSequential_block(self, ctx:SVParser.Sequential_blockContext):
        pass

    # Exit a parse tree produced by SVParser#sequential_block.
    def exitSequential_block(self, ctx:SVParser.Sequential_blockContext):
        pass


    # Enter a parse tree produced by SVParser#expr.
    def enterExpr(self, ctx:SVParser.ExprContext):
        pass

    # Exit a parse tree produced by SVParser#expr.
    def exitExpr(self, ctx:SVParser.ExprContext):
        pass


    # Enter a parse tree produced by SVParser#prog.
    def enterProg(self, ctx:SVParser.ProgContext):
        pass

    # Exit a parse tree produced by SVParser#prog.
    def exitProg(self, ctx:SVParser.ProgContext):
        pass



del SVParser