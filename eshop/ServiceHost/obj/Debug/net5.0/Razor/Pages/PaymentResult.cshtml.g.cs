#pragma checksum "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\PaymentResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7ab0a739c67299f6fdb5dae3d7dcb674c8be5d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_PaymentResult), @"mvc.1.0.razor-page", @"/Pages/PaymentResult.cshtml")]
namespace ServiceHost.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7ab0a739c67299f6fdb5dae3d7dcb674c8be5d9", @"/Pages/PaymentResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PaymentResult : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\PaymentResult.cshtml"
  
    ViewData["Title"] = "وضعیت پرداخت";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""breadcrumb-area section-space--half"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""breadcrumb-wrapper breadcrumb-bg"">
                    <div class=""breadcrumb-content"">
                        <h1 class=""breadcrumb-content__title"">وضعیت پرداخت</h1>
                        <ul class=""breadcrumb-content__page-map"">
                            <li>
                                <a href=""/"">صفحه اصلی</a>
                            </li>
                            <li class=""active"">
                               وضعیت
                            </li>

                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  page wrapper  =======-->
                <div class=""page-");
            WriteLiteral("wrapper\">\r\n                    <div class=\"page-content-wrapper\">\r\n");
#nullable restore
#line 37 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\PaymentResult.cshtml"
                         if (Model.Result.IsSuccessful)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"alert alert-success\">\r\n                                <p>\r\n                                    ");
#nullable restore
#line 41 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\PaymentResult.cshtml"
                               Write(Model.Result.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n                                <p>\r\n                                 شماره پیگیری :   <strong>");
#nullable restore
#line 44 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\PaymentResult.cshtml"
                                                     Write(Model.Result.IssueTrackingNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                </p>\r\n                            </div>\r\n");
#nullable restore
#line 47 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\PaymentResult.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"alert alert-danger\">\r\n                                <p>\r\n                                    ");
#nullable restore
#line 52 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\PaymentResult.cshtml"
                               Write(Model.Result.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n                               \r\n                            </div>\r\n");
#nullable restore
#line 56 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\PaymentResult.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.PaymentResultModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.PaymentResultModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.PaymentResultModel>)PageContext?.ViewData;
        public ServiceHost.Pages.PaymentResultModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
