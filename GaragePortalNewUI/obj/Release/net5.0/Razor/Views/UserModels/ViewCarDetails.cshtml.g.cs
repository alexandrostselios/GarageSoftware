#pragma checksum "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7329ca560e541fb2941d6f904408b4d0e617d573"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserModels_ViewCarDetails), @"mvc.1.0.view", @"/Views/UserModels/ViewCarDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7329ca560e541fb2941d6f904408b4d0e617d573", @"/Views/UserModels/ViewCarDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85a55a5ae804c6c3cc1a0dc4b198905acee6ca2c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_UserModels_ViewCarDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GaragePortalNewUI.Models.ServiceHistory>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateUserModelServiceHistory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("af"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "UserModels", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteUserModelServiceHistory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
  
    ViewData["Title"] = @Resource.GetKey("View_Car_Details");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
 if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.Admin.ToString())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7329ca560e541fb2941d6f904408b4d0e617d5735415", async() => {
                WriteLiteral("\r\n            <input type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 394, "\"", 441, 1);
#nullable restore
#line 11 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
WriteAttributeValue("", 402, Resource.GetKey("Add_Service_History"), 402, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-primary\" />\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-UserModelsID", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                                                                     WriteLiteral(ViewBag.CarDetailsID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["UserModelsID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-UserModelsID", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["UserModelsID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </p>\r\n");
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th>
                    ID
                </th>
                <th>
                    Service Date
                </th>
                <th>
                   Engineer
                </th>
                <th>
                    Kilometer at Service
                </th>
                <th>
                    Starting Price of Service
                </th>
                <th>
                    Final Price of Service
                </th>
                <th>
                    Service History
                </th>
                <th>
                    Car Image
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 46 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 50 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 53 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ServiceDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Surname));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 56 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ServiceKilometer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                   Write(Html.DisplayFor(modelItem => item.StartPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                   Write(Html.DisplayFor(modelItem => item.FinalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 71 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                         if (item.CarImage != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img");
            BeginWriteAttribute("src", " src=\"", 2425, "\"", 2492, 2);
            WriteAttributeValue("", 2431, "data:image/jpg;base64,", 2431, 22, true);
#nullable restore
#line 73 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
WriteAttributeValue(" ", 2453, Convert.ToBase64String(item.CarImage), 2454, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"50\" height=\"50\" />\r\n");
#nullable restore
#line 74 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7329ca560e541fb2941d6f904408b4d0e617d57313721", async() => {
#nullable restore
#line 77 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                                                                                                                                Write(Resource.GetKey("Delete"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 77 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                                                                                                               WriteLiteral(item.ID);

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
            WriteLiteral("\r\n                    </td>  \r\n                </tr>\r\n");
#nullable restore
#line 80 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 83 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
}
else if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.User.ToString()){

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table"">
            <thead>
                <tr>
                    <th>
                        Service Date
                    </th>
                    <th>
                        Engineer
                    </th>
                    <th>
                        Kilometer at Service
                    </th>
                    <th>
                        Starting Price of Service
                    </th>
                    <th>
                        Final Price of Service
                    </th>
                    <th>
                        Service History
                    </th>
                    <th>
                        Car Image
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 113 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 117 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ServiceDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 120 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Surname));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 120 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                                                                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 123 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ServiceKilometer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 126 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                       Write(Html.DisplayFor(modelItem => item.StartPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 129 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FinalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 132 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 135 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                             if (item.CarImage != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <img");
            BeginWriteAttribute("src", " src=\"", 4897, "\"", 4964, 2);
            WriteAttributeValue("", 4903, "data:image/jpg;base64,", 4903, 22, true);
#nullable restore
#line 137 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
WriteAttributeValue(" ", 4925, Convert.ToBase64String(item.CarImage), 4926, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"50\" height=\"50\" />\r\n");
#nullable restore
#line 138 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 141 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 144 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\UserModels\ViewCarDetails.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GaragePortalNewUI.Models.ServiceHistory>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
