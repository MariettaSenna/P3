using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebdevelopmentPeriode3.Pages;

public class PageHandeler : PageModel
{
//     //public int CounterCola { get; set; } = 0;
//
//     //public void OnGet(string action = "")
//     {
//         /*action = action.ToLower();
//
//         string counterStr = Request.Cookies["counter"];
//         if (counterStr == null) //cookie is not set (first time request or after reset)
//         {
//             Response.Cookies.Append("counter", CounterCola.ToString(), new CookieOptions()
//             {
//                 Expires = DateTimeOffset.Now.AddDays(30)
//             });
//             //Response.Cookies.Append("counter", Counter.ToString());
//         }
//         else
//         {
//             CounterCola = int.Parse(counterStr);  //Convert.ToInt32(counterStr)
//
//             if (action == "increment cola")
//             {
//                 CounterCola++;
//                 Response.Cookies.Append("counter", CounterCola.ToString());
//             } else if (action == "decrement cola")
//             {
//                 CounterCola--;
//                 Response.Cookies.Append("counter", CounterCola.ToString());
//             } 
//         }*/
//     }

    // nieuwe methode page handlers
    [BindProperty] public int Counter1 { get; set; } = 0;

    public void OnGet()
    {

    }

    public void OnPostIncrement()
    {

        Counter1++;
    }

    public void OnPostDecrement()
    {

        Counter1--;
    }

    [BindProperty()] public int Counter2 { get; set; }
    
 

    public void OnPostIncrementCounter2()
    {
        Counter2++;
    }

    public void OnPostDecrementCounter2()
    {
        Counter2--;
    }

}

