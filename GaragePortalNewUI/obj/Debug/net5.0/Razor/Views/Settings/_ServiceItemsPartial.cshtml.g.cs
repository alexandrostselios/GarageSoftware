#pragma checksum "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9da378840035712d7a04283d56c7ce5258b03750"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Settings__ServiceItemsPartial), @"mvc.1.0.view", @"/Views/Settings/_ServiceItemsPartial.cshtml")]
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
#line 1 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9da378840035712d7a04283d56c7ce5258b03750", @"/Views/Settings/_ServiceItemsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85a55a5ae804c6c3cc1a0dc4b198905acee6ca2c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Settings__ServiceItemsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GaragePortalNewUI.Models.ServiceItems>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("af"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ServiceItems", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteServiceItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div id=\"addServiceItem\"></div>\r\n<div id=\"editServiceItem\"></div>\r\n\r\n<button class=\"btn btn-sm btn-primary m-2\" id=\"btnAddServiceItem\" data-bs-toggle=\"ajax-modal\" data-bs-target=\"#addServiceItem\" data-url=\"");
#nullable restore
#line 7 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
                                                                                                                                    Write(Url.Action("AddServiceItemPartial","ServiceItems"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Add</button>\r\n\r\n<div id=\"totalInvoiceDiv\" class=\"scrollit\">\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 14 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
               Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 17 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
               Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 20 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
               Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th colspan=\"2\">Total Service Items: ");
#nullable restore
#line 22 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
                                                Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        \r\n        <tbody>\r\n");
#nullable restore
#line 27 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 31 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <button class=\"btn btn-sm btn-primary m-2\" id=\"btnEditServiceItem\" data-bs-toggle=\"ajax-modal\" data-bs-target=\"#editServiceItem\" data-url=\"");
#nullable restore
#line 40 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
                                                                                                                                                              Write(Url.Action("EditServiceItemPartial","ServiceItems",new{id = @item.ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 40 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
                                                                                                                                                                                                                                       Write(Resource.GetKey("Edit"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9da378840035712d7a04283d56c7ce5258b037509405", async() => {
#nullable restore
#line 43 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
                                                                                                                      Write(Resource.GetKey("Delete"));

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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
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
            WriteLiteral("\r\n                    </td>\r\n                    <td colspan =\"3\"></td>\r\n                </tr>\r\n");
#nullable restore
#line 47 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\Settings\_ServiceItemsPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<script type=""text/javascript"">
    console.log(11);
    $(function () {
        var addServiceItemDIVElement = $('#editServiceItem');
        console.log(33);
        $('button[data-bs-toggle=""ajax-modal""]').click(function (event) {
            console.log(44);
            var url = $(this).data('url');
            $.get(url).done(function (data) {
                console.log(55);
                addServiceItemDIVElement.html(data);
                addServiceItemDIVElement.find('.modal').modal('show');
            })
        })

        //Save Add Makeform data
        addServiceItemDIVElement.on('click', '[data-bs-save=""modal""]', function (event) {

            var form = $(this).parents('.modal').find('form');
            var actionUrl = form.attr(""action"");
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (data) {
                addServiceItemDIVElement.find('.modal').modal('hide');
        ");
            WriteLiteral("        location.reload(true);\r\n            })\r\n        })\r\n    })\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GaragePortalNewUI.Models.ServiceItems>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591