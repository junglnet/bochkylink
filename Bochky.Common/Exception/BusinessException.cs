using System;
// Спросить почему такая хрень.

namespace BochkyLink.Common.Exception
{
    /// <summary>
    /// Стандартное исключение уровня бизнес-логики
    /// </summary>
    public class BusinessException : System.Exception
    {
        public BusinessException() : base("Произошла ошибка при обработке данных") { }

        public BusinessException(string message) : base(message) { }         
    }
}
