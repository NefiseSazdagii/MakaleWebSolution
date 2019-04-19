﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.Entities.ViewModel
{
  public class KayitModel
    {
      
        [DisplayName("Kullanıcı adı"),
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string KullaniciAd { get; set; }

        [DisplayName("E-posta"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(70, ErrorMessage = "{0} max. {1} karakter olmalı."),
            EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-posta adresi giriniz.")]
        public string EMail { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            DataType(DataType.Password),
            StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Sifre { get; set; }

        [DisplayName("Şifre Tekrar"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            DataType(DataType.Password),
            StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı."),
            Compare("Sifre", ErrorMessage = "{0} ile {1} uyuşmuyor.")]
        public string SifreTekrar { get; set; }
    }
}