#pragma checksum "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6e888ce30cc5baa91d708a36bc5a7e9ee8f7bbf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Settings), @"mvc.1.0.view", @"/Views/Home/Settings.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6e888ce30cc5baa91d708a36bc5a7e9ee8f7bbf", @"/Views/Home/Settings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85a55a5ae804c6c3cc1a0dc4b198905acee6ca2c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Settings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GaragePortalNewUI.Models.UserModels>>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
  
    ViewData["Title"] = Resource.GetKey("Settings");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
 if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.Admin.ToString())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Welcome ");
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
          Write(ViewBag.UserType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
                              Write(ViewBag.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
                                            Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
                                                            Write(ViewBag.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("    <div>\r\n        <p>Default Language: </p>\r\n        <select>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6e888ce30cc5baa91d708a36bc5a7e9ee8f7bbf4916", async() => {
                WriteLiteral("English");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6e888ce30cc5baa91d708a36bc5a7e9ee8f7bbf5887", async() => {
                WriteLiteral("Greek");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </select>\r\n");
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 23 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
}
else if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.User.ToString())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Welcome user: ");
#nullable restore
#line 26 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
                Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 26 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
                                Write(ViewBag.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 27 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>You need to login first</p>\r\n");
#nullable restore
#line 32 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Home\Settings.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LanguageService Resource { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GaragePortalNewUI.Models.UserModels>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
