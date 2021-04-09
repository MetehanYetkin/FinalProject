using Core.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{//Sürekli newlemeleyim diye static
   public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Bakım zamanı";
        public static string ProductListed = "Ürünler listelendi ";
        public static string ProductCountOfCategoryError="Bir Kategoride En Fazla 10 ürün olabillir.";
        public static string ProductNameAlreadyExist="Aynı isimde bir Ürün Mevcut";
        public static string CategoryLimitExceded="Kategori Limiti dolu";
        public static string AuthorizationDenied="Yetkiniz yok .";
        public static string UserRegistered="Kayıt Oldu";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string PasswordError="Parola Hatası";
        public static string SuccessfulLogin="Başarılı Giriş";
        public static string UserAlreadyExists="Kullanıcı Mevcut";
        public static string AccessTokenCreated="Token oluşturuldu.";
    }
}
