#pragma checksum "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bca8013d49d215e6f35ce724b0c7ab0e716ee26"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BookShop.UI.Pages.User.Pages_User_Index), @"mvc.1.0.razor-page", @"/Pages/User/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bca8013d49d215e6f35ce724b0c7ab0e716ee26", @"/Pages/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91e4ebaf2319446633c9f77f2a1aa46dbf09d5bd", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_User_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/item.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n<div class=\"section\">\r\n    <div class=\"columns is-multiline is-mobile\">\r\n\r\n");
#nullable restore
#line 10 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
          

            foreach (var p in Model.Products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"column is-3-desktop is-4-tablet is-6-mobile\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1bca8013d49d215e6f35ce724b0c7ab0e716ee264390", async() => {
                WriteLiteral("\r\n\r\n                        <div class=\"card\">\r\n                            <div class=\"card-image\">\r\n                                <figure class=\"image is-3by4\">\r\n");
#nullable restore
#line 20 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
                                     if (p.Image != null)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <img");
                BeginWriteAttribute("src", " src=\"", 635, "\"", 698, 2);
                WriteAttributeValue("", 641, "data:image/jpeg;base64,", 641, 23, true);
#nullable restore
#line 22 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
WriteAttributeValue("", 664, Convert.ToBase64String(p.Image), 664, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 23 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1bca8013d49d215e6f35ce724b0c7ab0e716ee265978", async() => {
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
#line 27 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </figure>\r\n                            </div>\r\n                            <div class=\"card-content\">\r\n");
#nullable restore
#line 31 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
                                  
                                    string cssClass = "";
                                    string message = "";

                                    if (p.Available == 0)
                                    {
                                        cssClass = "is-succes";
                                        message = "Продается";
                                    }
                                    else if (p.Available == 1)
                                    {
                                        cssClass = "is-danger";
                                        message = "Снят с продажи";

                                    }
                                

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div");
                BeginWriteAttribute("class", " class=\"", 1841, "\"", 1904, 4);
                WriteAttributeValue("", 1849, "notification", 1849, 12, true);
                WriteAttributeValue(" ", 1861, "is-paddingless", 1862, 15, true);
                WriteAttributeValue(" ", 1876, "has-text-centered", 1877, 18, true);
#nullable restore
#line 47 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
WriteAttributeValue(" ", 1894, cssClass, 1895, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    ");
#nullable restore
#line 48 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
                               Write(message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                    <p class=\"title is-size-5\">\r\n                                        ");
#nullable restore
#line 51 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
                                   Write(p.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 51 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
                                             Write(p.Value);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </p>\r\n                                    <p class=\"subtitle is-size-9\">\r\n                                        Автор: ");
#nullable restore
#line 54 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
                                          Write(p.Author);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </p>\r\n                            </div>\r\n                        </div>\r\n                    ");
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
#line 15 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"
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
#line 60 "C:\Users\User\source\repos\BookShop\BookShop.UI\Pages\User\Index.cshtml"

            }

        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
