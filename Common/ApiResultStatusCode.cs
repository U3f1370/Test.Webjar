using System.ComponentModel.DataAnnotations;

namespace Common
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "عملیات با موفقیت انجام شد.")]
        Success = 200,

        [Display(Name = "خطایی در سرور رخ داده است")]
        ServerError = 500,

        [Display(Name = "پارامتر های ارسالی معتبر نیستند")]
        BadRequest = 400,

        [Display(Name = "یافت نشد")]
        NotFound = 404,

        [Display(Name = "یافت شد")]
        Found = 410,

        [Display(Name = "لیست خالی است")]
        ListEmpty = 204,

        [Display(Name = "خطایی در پردازش رخ داد")]
        LogicError = 409,

        [Display(Name = "خطای احراز هویت")]
        UnAuthorized = 403,

        [Display(Name = "محدودیت فروش")]
        SaleLimitation = 210,

        [Display(Name = "عدم وجود قیمت برحسب نوع مشتری")]
        NotFoundUserPrice = 419,
        [Display(Name = "وجود تداخل و مغایرت")]
        HasConflict = 419,
        [Display(Name = "عدم تداخل یا مغایرت")]
        NoConflict = 211,

        [Display(Name = "هیچ دسته ای اضافه نشده")]
        NoCategoryAdded = 411
    }
}