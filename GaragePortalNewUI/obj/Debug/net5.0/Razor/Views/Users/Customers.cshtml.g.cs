#pragma checksum "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f15dc0fef1a47d6f8cdaa4e579871a5cad9cbe18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Customers), @"mvc.1.0.view", @"/Views/Users/Customers.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f15dc0fef1a47d6f8cdaa4e579871a5cad9cbe18", @"/Views/Users/Customers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85a55a5ae804c6c3cc1a0dc4b198905acee6ca2c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_Customers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GaragePortalNewUI.Models.Users>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("af"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PdfCreator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreatePDF", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-entityType", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "UserModels", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewCustomerCars", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SendEmailToUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-userType", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
  
    ViewData["Title"] = @Resource.GetKey("List_of_Customers");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
 if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.Admin.ToString())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade"" id=""successModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""successModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body"">
                    <center><p>");
#nullable restore
#line 14 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                          Write(Resource.GetKey("Your_email_has_been_sent_successfully."));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></center>\r\n                    <center><button type=\"button\" class=\"btn btn-primary\" data-dismiss=\"modal\">OK</button></center>\r\n                </div>  \r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""modal fade"" id=""failedModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""failedModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body"">
                    <center>
                        <p>");
#nullable restore
#line 26 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                      Write(Resource.GetKey("Your_email_did_not_send."));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p>");
#nullable restore
#line 27 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                      Write(Resource.GetKey("Please_try_again_later."));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </center>\r\n                    <center><button type=\"button\" class=\"btn btn-primary\" data-dismiss=\"modal\">OK</button></center>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <div id=\"addCustomerDIV\"></div>\r\n    <div id=\"editCustomerDIV\"></div>\r\n    <div id=\"sendEmailToCustomer\"></div>\r\n    <button class=\"btn btn-sm btn-primary m-2\" id=\"btnAddCustomer\" data-bs-toggle=\"ajax-modal\" data-bs-target=\"#AddCustomer\" data-url=\"");
#nullable restore
#line 38 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                                                                                                                                  Write(Url.Action("CreateCustomerPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 38 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                                                                                                                                                                        Write(Resource.GetKey("Add_New_Customer"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n    <div>\r\n        <br><br>\r\n");
#nullable restore
#line 41 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
         using (Html.BeginForm("Customers", "Users", FormMethod.Get))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <table>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 46 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                   Write(Html.Partial("_SearchPartialView"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 51 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                   Write(Html.TextBox("searchValue",null, new {Class = "form-control",placeholder=@Resource.GetKey("Enter_Details_for_Search")}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <input type=\"submit\" id=\"Search\"");
            BeginWriteAttribute("value", " value=\"", 2404, "\"", 2438, 1);
#nullable restore
#line 54 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
WriteAttributeValue("", 2412, Resource.GetKey("Search"), 2412, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\" />\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f15dc0fef1a47d6f8cdaa4e579871a5cad9cbe1811543", async() => {
#nullable restore
#line 57 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                                                                                                             Write(Resource.GetKey("Download_Users"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-entityType", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["entityType"] = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n\r\n            </table>\r\n");
#nullable restore
#line 62 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 69 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
               Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th data-sort=\"string\">\r\n                    ");
#nullable restore
#line 72 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
               Write(Resource.GetKey("Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th data-sort=\"string\">\r\n                    ");
#nullable restore
#line 75 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
               Write(Resource.GetKey("Surname"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 78 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
               Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th data-sort=\"date\">\r\n                    ");
#nullable restore
#line 81 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
               Write(Resource.GetKey("Creation_Date"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 84 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
               Write(Resource.GetKey("Modified_Date"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th data-sort=\"date\">\r\n                    ");
#nullable restore
#line 87 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
               Write(Resource.GetKey("Last_Login_Date"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 90 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
               Write(Resource.GetKey("User_Photo"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n                <th colspan=\"3\">");
#nullable restore
#line 93 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                           Write(Resource.GetKey("Total_Customers"));

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 93 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                                                                Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 97 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 101 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 104 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 107 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Surname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 110 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 113 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 116 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ModifiedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 119 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                   Write(Html.DisplayFor(modelItem => item.LastLoginDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 122 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                         if (!(item.UserPhoto is null))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img");
            BeginWriteAttribute("src", " src=\"", 4959, "\"", 5027, 2);
            WriteAttributeValue("", 4965, "data:image/jpg;base64,", 4965, 22, true);
#nullable restore
#line 124 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
WriteAttributeValue(" ", 4987, Convert.ToBase64String(item.UserPhoto), 4988, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"50\" height=\"50\" />\r\n");
#nullable restore
#line 125 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f15dc0fef1a47d6f8cdaa4e579871a5cad9cbe1821686", async() => {
#nullable restore
#line 128 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                                                                                                                   Write(Resource.GetKey("View_Cars"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 128 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
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
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f15dc0fef1a47d6f8cdaa4e579871a5cad9cbe1824566", async() => {
#nullable restore
#line 131 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                                                                                                                                    Write(Resource.GetKey("Send_Email"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 131 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                                                                                            WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userType", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userType"] = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <button class=\"btn btn-sm btn-primary m-2\" id=\"btnEditCustomer\" data-bs-toggle=\"ajax-modal\" data-bs-target=\"#EditCustomer\" data-url=\"");
#nullable restore
#line 134 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                                                                                                                                                        Write(Url.Action("EditCustomerPartial",new{id = @item.ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 134 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                                                                                                                                                                                                               Write(Resource.GetKey("Edit"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                    </td>\r\n                    <td></td>\r\n                </tr>\r\n");
#nullable restore
#line 138 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 141 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p><center>You are not authorized to access this page</center></p>\r\n");
#nullable restore
#line 145 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(function () {
            var addCustomerDIVElement = $('#addCustomerDIV');

            $('button[data-bs-toggle=""ajax-modal""]').click(function (event) {
                var url = $(this).data('url');
                $.get(url).done(function (data) {
                    addCustomerDIVElement.html(data);
                    addCustomerDIVElement.find('.modal').modal('show');
                })
            })

            //Save Add Makeform data
            addCustomerDIVElement.on('click', '[data-bs-save=""modal""]', function (event) {

                var form = $(this).parents('.modal').find('form');
                var actionUrl = form.attr(""action"");
                var sendData = form.serialize();
                $.post(actionUrl, sendData).done(function (data) {
                    addCustomerDIVElement.find('.modal').modal('hide');
                    location.reload(true);
                })
            })
        })

        var ");
                WriteLiteral("message = \"");
#nullable restore
#line 174 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
                  Write(ViewBag.SuccessMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n");
#nullable restore
#line 175 "C:\Users\alexa\Desktop\Visual Studio Projects\GaragePortalNewUI\Views\Users\Customers.cshtml"
          
            ViewBag.SuccessMessage = "null";
        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        if (message == ""Successfully"") {
            console.log('Successfully');
            $(document).ready(function () {
                
                $('#successModal').modal('show');
            });
            //alert(message);
        } else if (message == ""Failed"") {
            console.log('Failed');
            $(document).ready(function () {
                $('#failedModal').modal('show');
            });
            //alert(message);
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GaragePortalNewUI.Models.Users>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591