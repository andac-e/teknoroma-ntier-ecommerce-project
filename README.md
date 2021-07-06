## teknoroma - Katmanlı Mimari .NET E-Ticaret Projesi
### Bu proje MVC platformunda katmanlı mimari yapısı ile, strateji ve tasarım desenleri kullanılarak yazılmıştır. 
* Projeyi çalıştırmak için **Project.WEBUI** içerisinde kök dizinde bulunan **Web.config** dosyasına gidilerek **Connection Strings** local server'inize göre düzenlenmelidir.
* Proje çalıştırıldıktan sonra veritabanına Bogus kütüphanesi ile fake verilerin veritabanına eklenebilmesi için aşağıdaki kullanıcılardan biri ile giriş yapılmalıdır.     
* Siparişin onaylanabilmesi için github profilimdeki **[Bank API](https://github.com/andac-e/bank-api)** projesinin çalışır halde olması gerekmektedir. 
* Ana katmanların yanı sıra projede **Mail Service**, **Image Uploader** ve **Cryptography** sınıfları bulunmaktadır. 
* Veritabanına kaydı yapılan tüm kullanıcı parolaları KVKK kapsamında şifrelenerek gönderilmektedir.
* Admin paneli ürünler listesinde güncel döviz kurları XML ile **[TCMB](http://www.tcmb.gov.tr/kurlar/today.xml)**'ndan güncel olarak çekilmektedir.

1. Admin
      - Kullanıcı Adı: **admin**
      - Parola: **admin**
      
2. Aktif Kullanıcı
      - Kullanıcı Adı: **user1**
      - Parola: **user1**      
            
3. Şube Müdürü
      - Kullanıcı Adı: **manager**
      - Parola: **manager**
      
4. Satış Sorumlusu
      - Kullanıcı Adı: **sales**
      - Parola: **sales**
                  
5. Depo Sorumlusu
      - Kullanıcı Adı: **ware1**
      - Parola: **ware1**

6. Muhabese Sorumlusu
      - Kullanıcı Adı: **acc11**
      - Parola: **acc11**
      
7. Teknik Servis
      - Kullanıcı Adı: **tech1**
      - Parola: **tech1**
