using System;
using System.Text.RegularExpressions;

namespace ActiveSpaceSystem.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidPhoneNumber(string phone, out string errorMessage)
        {
            errorMessage = string.Empty;
            string cleanPhone = phone?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(cleanPhone))
            {
                errorMessage = "الرجاء إدخال رقم الهاتف أولاً.";
                return false;
            }

            if (!Regex.IsMatch(cleanPhone, @"^[0-9]+$"))
            {
                errorMessage = "رقم الهاتف غير صحيح! يجب أن يحتوي على أرقام فقط بدون حروف أو رموز.";
                return false;
            }

            if (cleanPhone.Length < 6 || cleanPhone.Length > 15)
            {
                errorMessage = "طول رقم الهاتف غير منطقي! يجب أن يتراوح بين 6 إلى 15 رقماً.";
                return false;
            }

            return true;
        }

        public static bool IsValidCustomerName(string name, out string errorMessage)
        {
            errorMessage = string.Empty;
            string cleanName = name?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(cleanName))
            {
                errorMessage = "الرجاء إدخال اسم العميل.";
                return false;
            }

            // يدعم الحروف العربية والإنجليزية والمسافات
            if (!Regex.IsMatch(cleanName, @"^[a-zA-Z\u0600-\u06FF\s]+$"))
            {
                errorMessage = "اسم العميل غير صالح! يجب أن يحتوي الاسم على حروف ومسافات فقط بدون أرقام أو رموز خاصة.";
                return false;
            }

            if (cleanName.Length < 3)
            {
                errorMessage = "يجب ألا يقل اسم العميل عن 3 حروف لتفادي الأسماء الوهمية.";
                return false;
            }

            return true;
        }

        public static bool IsValidDecimalValue(string textValue, string fieldName, out double parsedValue, out string errorMessage)
        {
            errorMessage = string.Empty;
            parsedValue = 0;
            string cleanValue = textValue?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(cleanValue))
            {
                errorMessage = $"حقل ({fieldName}) مطلوب، لا يمكن تركه فارغاً.";
                return false;
            }

            if (!double.TryParse(cleanValue, out parsedValue) || parsedValue < 1)
            {
                errorMessage = $"القيمة المدخلة في حقل ({fieldName}) غير صحيحة! يرجى كتابة قيمة رقمية موجبة وتكون أكبر من الصفر.";
                return false;
            }

            return true;
        }
    }
}