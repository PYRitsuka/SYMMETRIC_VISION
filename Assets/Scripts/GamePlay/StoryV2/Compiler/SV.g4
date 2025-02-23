grammar SV;
// tokenization
LINE_COMMENT
    : '//' ~[\r\n]* -> skip
    ;
WS:   (' ' | '\t' | '\r'| '\n') -> skip;

CMD_BLOCK
    : 'cmd_block'
    ;

AT: 'at';
IF
    : 'if'
    ;

BOOLEAN_LITERAL
    : 'true'
    | 'false'
    ;
    

STRING_LITERAL
    : '\'' ( ~('\'' | '\\') | '\\' . )* '\''
    | '"' ( ~('"' | '\\') | '\\' . )* '"'
    ;

INTEGER_LITERAL
    : '-'? [0-9]+
    ;

FLOAT_LITERAL
    : '-'? [0-9]+ '.' [0-9]+
    ;

IDENTIFIER
    : [a-zA-Z_][a-zA-Z_0-9.]*
    ;



literal
    : STRING_LITERAL
    | INTEGER_LITERAL
    | FLOAT_LITERAL
    | BOOLEAN_LITERAL
    ;


//function call
function_call
    : function_name '(' arguments? ','? ')' ';'
    ;

function_name
    : IDENTIFIER
    ;

arguments
    : argument (',' argument)* 
    ;

argument
    : positional_argument
    | keyword_argument
    ;

positional_argument
    : literal
    ;

keyword_argument
    : IDENTIFIER '=' literal
    ;



parallel_bock: CMD_BLOCK '{' (parallel_bock_arg)* '}';
time_singature: AT (INTEGER_LITERAL | FLOAT_LITERAL);
parallel_bock_arg: time_singature ',' expr;
if_block: IF '(' cond_expr ')' '{' prog '}';
cond_expr: IDENTIFIER '==' BOOLEAN_LITERAL ;
sequential_block: '{' prog '}';

expr: function_call
    | parallel_bock 
    | if_block
    | parallel_bock_arg
    | sequential_block
    ;


// prog:  time_singature;
prog:   (expr )* ;