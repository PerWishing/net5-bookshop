#pragma checksum "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a79f47828fa71ded31947a1282c26b86feacef88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BookShop.UI.Pages.User.Pages_User_OrderManagementForCustomer), @"mvc.1.0.razor-page", @"/Pages/User/OrderManagementForCustomer.cshtml")]
namespace BookShop.UI.Pages.User
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
#line 1 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\_ViewImports.cshtml"
using BookShop.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a79f47828fa71ded31947a1282c26b86feacef88", @"/Pages/User/OrderManagementForCustomer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91e4ebaf2319446633c9f77f2a1aa46dbf09d5bd", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_User_OrderManagementForCustomer : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/item.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"section\">\r\n    <div class=\"columns is-multiline is-mobile\">\r\n\r\n");
#nullable restore
#line 8 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
          

            foreach (var p in Model.Orders)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"column is-3-desktop is-4-tablet is-6-mobile\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a79f47828fa71ded31947a1282c26b86feacef884511", async() => {
                WriteLiteral("\r\n                                <div class=\"card-image\">\r\n                                    <figure class=\"image is-3by4\">\r\n");
#nullable restore
#line 16 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                         if (p.Product.Image != null)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <img");
                BeginWriteAttribute("src", " src=\"", 661, "\"", 732, 2);
                WriteAttributeValue("", 667, "data:image/jpeg;base64,", 667, 23, true);
#nullable restore
#line 18 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
WriteAttributeValue("", 690, Convert.ToBase64String(p.Product.Image), 690, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 19 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a79f47828fa71ded31947a1282c26b86feacef886162", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 23 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </figure>\r\n                                </div>\r\n                                <div class=\"card-content\">\r\n");
#nullable restore
#line 27 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                      
                                        string cssClass = "";
                                        string message = "";

                                        if ((int)p.StatusForCustomer == 0)
                                        {
                                            cssClass = "has-text-link";
                                            message = "Не получил";
                                        }
                                        else if ((int)p.StatusForCustomer == 1)
                                        {
                                            cssClass = "has-text-success";
                                            message = "Получил";

                                        }
                                        else if ((int)p.StatusForCustomer == 3)
                                        {
                                            cssClass = "has-text-danger";
                                            message = "Отменил";

                                        }
                                        else if ((int)p.StatusForCustomer == 4)
                                        {
                                            cssClass = "has-text-danger";
                                            message = "Отменил на почте";

                                        }
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                      
                                        string cssClass1 = "";
                                        string message1 = "";

                                        if ((int)p.StatusForSeller == 0)
                                        {
                                            cssClass1 = "has-text-black";
                                            message1 = "Нет статуса";
                                        }
                                        else if ((int)p.StatusForSeller == 1)
                                        {
                                            cssClass1 = "has-text-success";
                                            message1 = "Принял";

                                        }
                                        else if ((int)p.StatusForSeller == 2)
                                        {
                                            cssClass1 = "has-text-link";
                                            message1 = "Отправил";

                                        }
                                        else if ((int)p.StatusForSeller == 3)
                                        {
                                            cssClass1 = "has-text-success";
                                            message1 = "Получил деньги";

                                        }
                                        else if ((int)p.StatusForCustomer == 4)
                                        {
                                            cssClass1 = "has-text-danger";
                                            message1 = "Отменил";

                                        }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    <p class=\"title is-size-5\">\r\n                                        ");
#nullable restore
#line 91 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                   Write(p.Product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 91 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                                     Write(p.Product.Value);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </p>\r\n                                    <p class=\"is-size-7\">\r\n                                        ");
#nullable restore
#line 94 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                   Write(p.Product.Author);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </p>\r\n                                    <p");
                BeginWriteAttribute("class", " class=\"", 4733, "\"", 4761, 2);
#nullable restore
#line 96 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
WriteAttributeValue("", 4741, cssClass1, 4741, 10, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue(" ", 4751, "is-size-7", 4752, 10, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        Продавец: ");
#nullable restore
#line 97 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                             Write(p.Seller);

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>(");
#nullable restore
#line 97 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                                             Write(message1);

#line default
#line hidden
#nullable disable
                WriteLiteral(")</span>\r\n                                    </p>\r\n                                    <p");
                BeginWriteAttribute("class", " class=\"", 4930, "\"", 4957, 2);
#nullable restore
#line 99 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
WriteAttributeValue("", 4938, cssClass, 4938, 9, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue(" ", 4947, "is-size-7", 4948, 10, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        Покупатель: ");
#nullable restore
#line 100 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                               Write(p.Customer);

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>(");
#nullable restore
#line 100 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                                                 Write(message);

#line default
#line hidden
#nullable disable
                WriteLiteral(")</span>\r\n                                    </p>\r\n                                    <p class=\"is-size-7\">\r\n                                        Номер заказа: ");
#nullable restore
#line 103 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                                 Write(p.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </p>\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"
                                                   WriteLiteral(p.Id);

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
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 108 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\OrderManagementForCustomer.cshtml"

            }

        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    \r\n ");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookShop.UI.Pages.User.OrderManagementForCustomerModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BookShop.UI.Pages.User.OrderManagementForCustomerModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BookShop.UI.Pages.User.OrderManagementForCustomerModel>)PageContext?.ViewData;
        public BookShop.UI.Pages.User.OrderManagementForCustomerModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
