#pragma checksum "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eed6bc9934a34225fc2727cd67f60ad9cd7a51e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_ProductCategory), @"mvc.1.0.razor-page", @"/Pages/ProductCategory.cshtml")]
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
#line 1 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eed6bc9934a34225fc2727cd67f60ad9cd7a51e6", @"/Pages/ProductCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ProductCategory : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Productcategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
  
    ViewData["Title"] = "فروشگاه آنلاین / گروه محصولات ";

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
                        <h2 class=""breadcrumb-content__title"">لیست محصولات (");
#nullable restore
#line 15 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                                       Write(Model.ProductCategoryWithProduct.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</h2>\r\n                        <ul class=\"breadcrumb-content__page-map\">\r\n                            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e66303", async() => {
                WriteLiteral("صفحه اصلی");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                            <li class=\"active\">");
#nullable restore
#line 18 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                          Write(Model.ProductCategoryWithProduct.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        </ul>\r\n                        <br />\r\n                        <p>");
#nullable restore
#line 21 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                      Write(Model.ProductCategoryWithProduct.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 21 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                                     Write(Model.ProductCategoryWithProduct.Products.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" محصول )</p>
                    </div>
                    <!--=======  End of breadcrumb content  =======-->
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
                                <!--=======  shop page header  =======-->
                                <div class=""shop-header"">
                                    <div class=""shop-header__left"">
                                        <div class=""shop-header__left__message"">
                   ");
            WriteLiteral(@"                         Showing 1 to 9 of 15 (2 Pages)
                                        </div>
                                    </div>

                                    <div class=""shop-header__right"">

                                        <div class=""single-select-block d-inline-block"">
                                            <span class=""select-title"">Show:</span>
                                            <select>
                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e610114", async() => {
                WriteLiteral("10");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e611318", async() => {
                WriteLiteral("20");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e612522", async() => {
                WriteLiteral("30");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e613726", async() => {
                WriteLiteral("40");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                            </select>
                                        </div>

                                        <div class=""single-select-block d-inline-block"">
                                            <span class=""select-title"">Sort By:</span>
                                            <select class=""pr-0"">
                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e615285", async() => {
                WriteLiteral("Default");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e616494", async() => {
                WriteLiteral("Name (A-Z)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e617706", async() => {
                WriteLiteral("Price (min - max)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e618925", async() => {
                WriteLiteral("Color");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <!--=======  End of shop page header  =======-->
                            </div>

                            <div class=""col-lg-12"">
                                <!--=======  shop page content  =======-->
                                <div class=""shop-page-content"">

                                    <div class=""row shop-product-wrap grid three-column"">
");
#nullable restore
#line 79 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                         foreach (var Product in Model.ProductCategoryWithProduct.Products)
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
#line 85 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                         if (Product.hasDiscount)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"single-grid-product__label\">\r\n                                                                <span class=\"new\">");
#nullable restore
#line 88 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                                             Write(Product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</span>\r\n                                                            </div>\r\n");
#nullable restore
#line 90 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        <a href=\"single-product.html\">\r\n                                                            <img");
            BeginWriteAttribute("src", " src=\"", 5316, "\"", 5354, 2);
            WriteAttributeValue("", 5322, "/ProductPicture/", 5322, 16, true);
#nullable restore
#line 93 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
WriteAttributeValue("", 5338, Product.Picture, 5338, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 5355, "\"", 5384, 1);
#nullable restore
#line 93 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
WriteAttributeValue("", 5363, Product.PictureTitle, 5363, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 5403, "\"", 5494, 1);
#nullable restore
#line 94 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
WriteAttributeValue("", 5475, Product.PictureAlt, 5475, 19, false);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e624564", async() => {
#nullable restore
#line 103 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                                                                                                               Write(Product.CategoryName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 103 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                                                                WriteLiteral(Model.ProductCategoryWithProduct.Slug);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eed6bc9934a34225fc2727cd67f60ad9cd7a51e628105", async() => {
                WriteLiteral("\r\n                                                                ");
#nullable restore
#line 116 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                           Write(Product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                        </h3>\r\n\r\n                                                        <p class=\"single-grid-product__price\">\r\n\r\n");
#nullable restore
#line 122 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                             if (Product.hasDiscount)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"discounted-price\">");
#nullable restore
#line 124 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                                                          Write(Product.PriceWithDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                                <span class=\"main-price discounted\">");
#nullable restore
#line 125 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                                                               Write(Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n");
#nullable restore
#line 126 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"

                                                            }
                                                            else
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"main-price\">");
#nullable restore
#line 130 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                                                    Write(Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 131 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"

                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </p>\r\n");
#nullable restore
#line 135 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                         if (Product.hasDiscount)
                                                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"product-countdown\" data-countdown=\"");
#nullable restore
#line 138 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
                                                                                                      Write(Product.Discountexpirydate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></div>\r\n");
#nullable restore
#line 139 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"
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
#line 145 "C:\Users\mReza\source\repos\Project_Eshop\Code\eshop\ServiceHost\Pages\ProductCategory.cshtml"

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                                    </div>

                                </div>

                                <!--=======  pagination area =======-->
                                <div class=""pagination-area"">
                                    <div class=""pagination-area__left"">
                                        Showing 1 to 9 of 11 (2 Pages)
                                    </div>
                                    <div class=""pagination-area__right"">
                                        <ul class=""pagination-section"">
                                            <li>
                                                <a class=""active"" href=""#"">1</a>
                                            </li>
                                            <li>
                                                <a href=""#"">2</a>
                                            </li>
                                        </ul>
                                    </div>
                ");
            WriteLiteral(@"                </div>
                                <!--=======  End of pagination area  =======-->
                                <!--=======  End of shop page content  =======-->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.ProductCategoryPageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.ProductCategoryPageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.ProductCategoryPageModel>)PageContext?.ViewData;
        public ServiceHost.Pages.ProductCategoryPageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591