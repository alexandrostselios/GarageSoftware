#pragma checksum "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "650484083ba89823ae92f971b896b75f81e820da469936510cd0d3961192f7b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_MyProfile), @"mvc.1.0.view", @"/Views/Users/MyProfile.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI

#nullable disable
    ;
#nullable restore
#line 2 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI.Models

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"650484083ba89823ae92f971b896b75f81e820da469936510cd0d3961192f7b3", @"/Views/Users/MyProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"da4eb8d6136306ebe2b493ae02b2be3e560331e9b2fef64dac5a5a7d88685240", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_MyProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GaragePortalNewUI.Models.UserViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("af"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditMyProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
  
    ViewData["Title"] = @Resource.GetKey("My_Profile");

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<h1>\r\n    ");
            Write(
#nullable restore
#line 9 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
     Resource.GetKey("My_Profile")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("         \r\n");
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
     if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.Admin.ToString())
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        ");
            WriteLiteral("Admin\r\n");
#nullable restore
#line 13 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
    }else if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.Employee.ToString())
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        ");
            WriteLiteral("Employee\r\n");
#nullable restore
#line 16 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral("</h1>\r\n\r\n<div>\r\n    <dl class=\"row\"> \r\n        <dt class=\"col-sm-2\">\r\n            ");
            Write(
#nullable restore
#line 22 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Resource.GetKey("Surname")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            Write(
#nullable restore
#line 25 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Html.DisplayFor(model => model.Surname)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            Write(
#nullable restore
#line 28 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Resource.GetKey("Name")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            Write(
#nullable restore
#line 31 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Html.DisplayFor(model => model.Name)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            Write(
#nullable restore
#line 34 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Html.DisplayNameFor(model => model.Email)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            Write(
#nullable restore
#line 37 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Html.DisplayFor(model => model.Email)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            Write(
#nullable restore
#line 40 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Resource.GetKey("Creation_Date")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            Write(
#nullable restore
#line 43 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Html.DisplayFor(model => model.CreationDate)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            Write(
#nullable restore
#line 46 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Resource.GetKey("Last_Login_Date")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dt class=\"col-sm-2\">\r\n            ");
            Write(
#nullable restore
#line 50 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
             Html.DisplayFor(model => model.LastLoginDate)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dt>\r\n\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "650484083ba89823ae92f971b896b75f81e820da469936510cd0d3961192f7b39690", async() => {
                Write(
#nullable restore
#line 56 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
                                                                         Resource.GetKey("Edit")

#line default
#line hidden
#nullable disable
                );
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 56 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
                                                            ViewBag.ID

#line default
#line hidden
#nullable disable
            );
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
            WriteLiteral("\r\n");
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public 
#nullable restore
#line 2 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
        LanguageService

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 2 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Users\MyProfile.cshtml"
                        Resource

#line default
#line hidden
#nullable disable
         { get; private set; }
         = default!;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GaragePortalNewUI.Models.UserViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
