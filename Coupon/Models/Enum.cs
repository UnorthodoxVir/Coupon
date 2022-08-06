using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coupon.Models
{
    public class Enum
    {


       

        public enum DiscountType
        {
             ورش = 1,
            مغاسل = 2,
            تلميع = 3
        }
        public enum InvoiceType
        {
            بيع = 1,
            مرتجع_بيع = 2
        }
        public enum InvoiceStatus
        {
            مدفوعة = 0,
            غير_مدفوعة = 1
        }
        public enum PaymentType
        {
            نقداً = 1,
            شبكة = 2,
            دفع_الكتروني = 3,
            حوالة_بنكية
        }
        public enum City
        {
            تبوك,
            الرياض,
            الطائف,
            مكة_المكرمة,
            حائل,
            بريدة,
            الهفوف,
            الدمام,
            المدينة_المنورة,
            ابها,
            جازان,
            جدة,
            المجمعة,
            الخبر,
            حفر_الباطن,
            خميش_مشيط,
            القطيف,
            عنيزة,
            الجبيل,
            النعيرية,
            الظهران,
            الوجه,
            بقيق,
            الزلفي,
            خيبر,
            الغاط,
            املج,
            رابغ,
            عفيف,
            ثادق,
            سيهات,
            تاروت,
            ينبع,
            شقراء,
            الدوادمي,
            الدرعية,
            القويعية,
            المزاحمية,
            بدر,
            الخرج,
            الدلم,
            الشنان,
            الخرمة,
            الجموم,
            المجاردة,
            السليل,
            تثليث,
            بيشة,
            الباحة,
            القنفذة,
            محايل,
            ثول,
            ضبا,
            تربه,
            صفوى,
            عنك,
            طريف,
            عرعر,
            القريات,
            سكاكا,
            رفحاء,
            دومة_الجندل,
            الرس,
            المذنب,
            الخفجي,
            رياض_الخبراء,
            البدائع,
            رأس_تنورة,
            البكيرية,
            الشماسية,
            الحريق,
            ليلى,
            بللسمر,
            شرورة,
            نجران,
            صبيا,
            صامطة,
            الأحساء
        }
        public enum UserType
        {
            Admin = 0,
            Owner = 1,
            Employee = 2,
            Manager = 3,
            CallCenter =4
        }
        public enum AttachmentsType
        {
            Images = 1,
            Pricing = 2
        }
        public enum PricingStatus
        {
            Pendding = 0,
            Acceptect = 1,
            Rejected = 2
        }
        public enum TemplateType
        {
            VehicleEntry = 1,
            VehicleExit = 2,
            NewInvoice = 3,
            OfferPrice = 4,
            General =5
        }
        public enum TemplateChannel
        {
            SMS = 1,
            Email = 2
        }
        
        public enum SubscriptionType
        {
            فعلي = 0,
            تجربة = 1
        }

        public enum CommunicationPurpose
        {
            Subscription_Request,
            Trial,
            integration_Request,
            General
        }
        public enum CommunicationStatus
        {
            New,
            Closed
        }

        public enum CustomerSource
        {
            تويتر,
            انستقرام,
            لينكدان,
            يوتيوب,
            قوقل,
            توصية,
            كول_سنتر,
            وتساب
        }

        public enum ActivatyType
        {
            اتصال_وارد,
            اتصال_صادر
        }

        public enum ActivatyTags
        {
            المخزون,
            الصيانة,
            المبيعات,
            المشتريات,
            الحسابات,
           الدعم_الفني,
           عرض_سعر,
           استفسار_عام
        }

        public enum OrderStatus
        {
            جديد,
            مكتمل,
            ملغي
        }
        public enum InvoiceSize
        {
            A4,
            Small_Receipt
        }

    }


}
