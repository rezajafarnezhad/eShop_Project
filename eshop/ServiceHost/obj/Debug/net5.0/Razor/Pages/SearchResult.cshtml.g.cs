#pragma checksum "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73db82fca78958fd79907691c9eb9cde93b8e3c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_SearchResult), @"mvc.1.0.razor-page", @"/Pages/SearchResult.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73db82fca78958fd79907691c9eb9cde93b8e3c7", @"/Pages/SearchResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SearchResult : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Productcategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
  
    ViewData["Title"] = "فروشگاه آنلاین / نتیجه جستجو ";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""breadcrumb-area section-space--half"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  breadcrumb wrpapper  =======-->
                <div class=""breadcrumb-wrapper breadcrumb-bg"">
                    <!--=======  breadcrumb content  =======-->
                    <div class=""breadcrumb-content"">
                        <h2 class=""breadcrumb-content__title"">نتیجه جستجو : (");
#nullable restore
#line 17 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                                        Write(ViewData["Value"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("  -  ");
#nullable restore
#line 17 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                                                               Write(Model.Products.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" محصول) </h2>                       
                    </div>
                    
                </div>
                <!--=======  End of breadcrumb wrpapper  =======-->
            </div>
        </div>
    </div>
</div>
<!--====================  End of breadcrumb area  ====================-->
<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  shop page wrapper  =======-->
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">
                        <div class=""row"">

                            <div class=""col-lg-12"">
                                <!--=======  shop page content  =======-->
                                <div class=""shop-page-content"">

                                    <div class=""row shop-product-wrap grid three-column"">
");
#nullable restore
#line 41 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                         foreach (var Product in Model.Products)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""col-12 col-lg-3 col-md-4 col-sm-5"">
                                                <!--=======  product grid view  =======-->
                                                <div class=""single-grid-product grid-view-product"">
                                                    <div class=""single-grid-product__image"">
");
#nullable restore
#line 47 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                         if (Product.hasDiscount)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"single-grid-product__label\">\r\n                                                                <span class=\"new\">");
#nullable restore
#line 50 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                                             Write(Product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</span>\r\n                                                            </div>\r\n");
#nullable restore
#line 52 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        <a href=\"single-product.html\">\r\n                                                            <img");
            BeginWriteAttribute("src", " src=\"", 2713, "\"", 2751, 2);
            WriteAttributeValue("", 2719, "/ProductPicture/", 2719, 16, true);
#nullable restore
#line 55 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
WriteAttributeValue("", 2735, Product.Picture, 2735, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 2752, "\"", 2781, 1);
#nullable restore
#line 55 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
WriteAttributeValue("", 2760, Product.PictureTitle, 2760, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 2800, "\"", 2891, 1);
#nullable restore
#line 56 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
WriteAttributeValue("", 2872, Product.PictureAlt, 2872, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">

                                                        </a>


                                                    </div>
                                                    <div class=""single-grid-product__content"">
                                                        <div class=""single-grid-product__category-rating"">
                                                            <span class=""category"">
                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73db82fca78958fd79907691c9eb9cde93b8e3c79808", async() => {
#nullable restore
#line 65 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                                                                                              Write(Product.CategoryName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                                                                WriteLiteral(Product.CategorySlug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                            </span>
                                                            <span class=""rating"">
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star-outline""></i>
                                                            </span>
                                                        </div>

                                                        <h3 class=""single-grid-product__title"">
                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73db82fca78958fd79907691c9eb9cde93b8e3c713322", async() => {
                WriteLiteral("\r\n                                                                ");
#nullable restore
#line 78 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                           Write(Product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                        </h3>\r\n\r\n                                                        <p class=\"single-grid-product__price\">\r\n\r\n");
#nullable restore
#line 84 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                             if (Product.hasDiscount)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"discounted-price\">");
#nullable restore
#line 86 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                                                          Write(Product.PriceWithDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                                <span class=\"main-price discounted\">");
#nullable restore
#line 87 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                                                               Write(Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n");
#nullable restore
#line 88 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"

                                                            }
                                                            else
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"main-price\">");
#nullable restore
#line 92 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                                                    Write(Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 93 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"

                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </p>\r\n");
#nullable restore
#line 97 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                         if (Product.hasDiscount)
                                                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"product-countdown\" data-countdown=\"");
#nullable restore
#line 100 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                                                                      Write(Product.Discountexpirydate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></div>\r\n");
#nullable restore
#line 101 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    </div>
                                                </div>
                                                <!--=======  End of product grid view  =======-->

                                            </div>
");
#nullable restore
#line 107 "C:\Users\mReza\source\repos\Orginal\Project_Eshop\Code\eshop\ServiceHost\Pages\SearchResult.cshtml"

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                                    </div>

                                </div>

                            
                            </div>
                        </div>
                    </div>
                </div>
                <!--=======  End of shop page wrapper  =======-->
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.SearchResultModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.SearchResultModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.SearchResultModel>)PageContext?.ViewData;
        public ServiceHost.Pages.SearchResultModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
