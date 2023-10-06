using System.ComponentModel.DataAnnotations;
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo

namespace TravelingSalesman;

public enum City
{
    [Display(Name = "Prague")]
    Prague,
    
    [Display(Name = "Brno")]
    Brno,
    
    [Display(Name = "Ostrava")]
    Ostrava,
    
    [Display(Name = "Liberec")]
    Liberec,
    
    [Display(Name = "Plzeň")]
    Plzen,
    
    [Display(Name = "České Budějovice")]
    CeskeBudejovice,
    
    [Display(Name = "Únětice")]
    Unetice,
    
    [Display(Name = "Svijany")]
    Svijany,
    
    [Display(Name = "Zlín")]
    Zlin,
    
    [Display(Name = "Most")]
    Most
}