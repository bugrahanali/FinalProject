using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constents_sabitler_
{
   public static class Messages
    {
        
        public static string ProductAdded = " Ürün eklendi";
        public static string ProductNameInvalid = " Ürün eklendi";
        public static string ProductsListed="ürünler listelendi";
        public static string  MaintenanceTime="Sistem temizlikte ";
        public static string ProductCountOfCategoryError="Kategoride en fazla 10 ürün bulunabilir.";
        public static string ProductNameAlreadyexist="Bu isimde zaten başka bir isim var";
        public static string CategoryLimitExceded="kategori limiti aşıldı";
        public static string AuthorizationDenied="yetkiniz yok";
        public static string UserAlreadyExists;
        public static string SuccessfulLogin;
        public static string PasswordError;
        public static string UserNotFound;
        public static string AccessTokenCreated;
    }
}
