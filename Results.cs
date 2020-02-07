using XPServerBL.HelperClasses;

namespace XPServerBL.Utils
{
    public static class Results
    {
        //alterar esta descrições, é só placeholder por agora. 0-100 reservado para erros de sistema.
        //SYSTEM CODES CONSTANTS
        public static Result Ok = new Result(("000", "Success."), true);
        public static Result UnhandledError = new Result(("001", "An error occured on server side."));
        public static Result PagaAqui_FailedAuth = new Result(("002", "Authentication with PagaAqui failed."));
        public static Result PagaAqui_FailedRequest = new Result(("004", "Request with PagaAqui failed."));
        public static Result PagaAqui_FailedOperation = new Result(("005", "Operation with PagaAqui failed."));
        public static Result PagaAqui_BadResponse = new Result(("006", "PagaAqui bad response."));
        public static Result PagaAqui_EmptyProductTypes = new Result(("007", "Empty product types"));

        //VALIDATION CONSTANTS
        public static Result InvalidTerminal =   new Result(("101", "The provided terminal is invalid."));
        public static Result InvalidSession =    new Result(("102", "The provided session is invalid."));
        public static Result InvalidSequence =   new Result(("103", "The provided sequence is invalid."));
        public static Result InvalidFieldData =  new Result(("104", "The provided field value is invalid."));
    }   
}