namespace Domain.FluentValidations
{
    namespace HBSIS.Padawan.Produtos.Domain
    {
        public sealed class Error
        {
            public Error(string fieldName, string message)
            {
                FieldName = fieldName;
                Message = message;
            }

            public string FieldName { get; private set; }
            public string Message { get; private set; }
        }
    }
}