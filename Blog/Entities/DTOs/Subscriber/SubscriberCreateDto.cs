using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Subscriber
{
    public class SubscriberCreateDto
    {
        [EmailAddress(ErrorMessage = "Email adresi doğru formatta değil!")]
        [Required(ErrorMessage = "Lütfen bir Email adresi giriniz")]
        public string Email { get; set; }
    }
}
