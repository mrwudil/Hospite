#pragma checksum "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "925dbe2af42a4d508d8789811a178267823ed526"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_ViewVisitors), @"mvc.1.0.view", @"/Views/Dashboard/ViewVisitors.cshtml")]
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
#line 1 "C:\Users\hp\source\repos\Hospite\Hospite\Views\_ViewImports.cshtml"
using Hospite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\source\repos\Hospite\Hospite\Views\_ViewImports.cshtml"
using Hospite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hp\source\repos\Hospite\Hospite\Views\_ViewImports.cshtml"
using Hospite.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hp\source\repos\Hospite\Hospite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hp\source\repos\Hospite\Hospite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"925dbe2af42a4d508d8789811a178267823ed526", @"/Views/Dashboard/ViewVisitors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6752435758b10ef01a64513dadc873ee5c6b12bb", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_ViewVisitors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SignOutViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GrantAccess", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Access", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning ml-auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
   
    var newTimeOut = string.Empty ;
    if (Model.TimeOut < DateTime.Now.AddHours(-24))
    {
        newTimeOut = "Not";
    }
   

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row d-flex justify-content-center align-content-center pt-5"" style=""margin-top:2vh;"">
    <div class=""col-lg-8 col-sm-12 box-shadow border border-0 pb-3"">
        <div class=""col-sm-12 d-flex flex-column text-center p-3"">


            <div");
            BeginWriteAttribute("class", " class=\"", 432, "\"", 440, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <h3 class=\"font-weight-bolder\" style=\"color: #0094ff;\">Visitor Details</h3>\r\n            </div>\r\n\r\n\r\n");
#nullable restore
#line 22 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
             if (Model.Cancelled == false && User.IsInRole("Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "925dbe2af42a4d508d8789811a178267823ed5266715", async() => {
                WriteLiteral("Grant Access");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-tag", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
                                                                                                  WriteLiteral(Model.TagNo);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tag"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-tag", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tag"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 25 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"

            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
                                                                                                                                                                                           

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 33 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
             if (Model.GrantedAccess == false && Model.Cancelled == false)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 class=\"text-danger font-weight-bolder\">\r\n                    No Access Granted Yet\r\n                </h6>\r\n");
#nullable restore
#line 38 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-sm-12 text-right\">\r\n\r\n");
#nullable restore
#line 44 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
             if (User.IsInRole("Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "925dbe2af42a4d508d8789811a178267823ed52610807", async() => {
                WriteLiteral(" Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 47 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "925dbe2af42a4d508d8789811a178267823ed52612504", async() => {
                WriteLiteral(" Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 51 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>



        <div class=""col-sm-12 d-flex justify-content-center align-content-center pt-4 p-2"">

            <div class=""col-12 d-flex justify-content-center align-content-center font-weight-bold "">
                <div class=""col-lg-6"">
                    <div class=""row mb-3"">
                        <label for=""Name"" class=""col-sm-4 col-form-label"">Full Name</label>
                        <div class=""col-sm-8"">
                            <input class=""form-control""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 2184, "\"", 2216, 1);
#nullable restore
#line 64 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 2198, Model.VisitorName, 2198, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n                        </div>\r\n                    </div>\r\n\r\n");
#nullable restore
#line 68 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
                     if (User.IsInRole("Admin"))
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"row mb-3\">\r\n                            <label for=\"Name\" class=\"col-sm-4 col-form-label\">Email</label>\r\n                            <div class=\"col-sm-8\">\r\n                                <input class=\"form-control\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 2618, "\"", 2644, 1);
#nullable restore
#line 74 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 2632, Model.Email, 2632, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n                            </div>\r\n                        </div>\r\n");
            WriteLiteral("                        <div class=\"row mb-3\">\r\n                            <label for=\"Phome\" class=\"col-sm-4 col-form-label\">Gender</label>\r\n                            <div class=\"col-sm-8\">\r\n                                <input class=\"form-control\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 2981, "\"", 3008, 1);
#nullable restore
#line 81 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 2995, Model.Gender, 2995, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 84 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                    <div class=\"row mb-3\">\r\n                        <label for=\"Phome\" class=\"col-sm-4 col-form-label\">Contact Name</label>\r\n                        <div class=\"col-sm-8\">\r\n                            <input class=\"form-control\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 3364, "\"", 3396, 1);
#nullable restore
#line 92 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 3378, Model.PhoneNumber, 3378, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                        </div>
                    </div>

                    <div class=""row mb-3"">
                        <label for=""Time"" class=""col-sm-4 col-form-label"">Booking Time</label>
                        <div class=""col-sm-8"">
                            <input class=""form-control""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 3714, "\"", 3746, 1);
#nullable restore
#line 99 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 3728, Model.BookingTime, 3728, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                        </div>
                    </div>
                    <div class=""row mb-3"">
                        <label for=""tag"" class=""col-sm-4 col-form-label"">Tag No</label>
                        <div class=""col-sm-8"">
                            <input class=""form-control""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 4055, "\"", 4081, 1);
#nullable restore
#line 105 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 4069, Model.TagNo, 4069, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 108 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
                     if (User.IsInRole("Admin"))
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"row mb-3\">\r\n                            <label for=\"Time\" class=\"col-sm-4 col-form-label\">Address</label>\r\n                            <div class=\"col-sm-8\">\r\n                                <input class=\"form-control\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 4483, "\"", 4568, 3);
#nullable restore
#line 114 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 4497, Model.Address.StreetNo, 4497, 23, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 114 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue(" ", 4520, Model.Address.AddressTitle, 4521, 27, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 114 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue(" ", 4548, Model.Address.City, 4549, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 117 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n\r\n");
#nullable restore
#line 121 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
                 if (User.IsInRole("Admin"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-lg-6"">


                        <div class=""row mb-3"">
                            <label for=""tag"" class=""col-sm-4 col-form-label"">Purpose</label>
                            <div class=""col-sm-8"">
                                <input class=""form-control""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 5066, "\"", 5094, 1);
#nullable restore
#line 129 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 5080, Model.Purpose, 5080, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                            </div>
                        </div>

                        <div class=""row mb-3"">
                            <label for=""Name"" class=""col-sm-4 col-form-label"">To Whom</label>
                            <div class=""col-sm-8"">
                                <input class=""form-control""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 5431, "\"", 5458, 1);
#nullable restore
#line 136 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 5445, Model.ToWhom, 5445, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                            </div>
                        </div>

                        <div class=""row mb-3"">
                            <label for=""Phome"" class=""col-sm-4 col-form-label"">From Where</label>
                            <div class=""col-sm-8"">
                                <input class=""form-control""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 5799, "\"", 5829, 1);
#nullable restore
#line 143 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 5813, Model.FromWhere, 5813, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                            </div>
                        </div>
                        <div class=""row mb-3"">
                            <label for=""Phome"" class=""col-sm-4 col-form-label"">Time In</label>
                            <div class=""col-sm-8"">
                                <input class=""form-control""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 6165, "\"", 6192, 1);
#nullable restore
#line 149 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 6179, Model.TimeIn, 6179, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                            </div>
                        </div>
                        <div class=""row mb-3"">
                            <label for=""Phome"" class=""col-sm-4 col-form-label"">Time Out</label>
                            <div class=""col-sm-8"">
");
#nullable restore
#line 155 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
                                 if (newTimeOut == "Not")
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <input class=\"form-control\" placeholder=\"Not Signed Out\" disabled>\r\n");
#nullable restore
#line 159 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <input class=\"form-control\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 6841, "\"", 6869, 1);
#nullable restore
#line 162 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
WriteAttributeValue("", 6855, Model.TimeOut, 6855, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n");
#nullable restore
#line 163 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n\r\n                    </div>\r\n");
#nullable restore
#line 168 "C:\Users\hp\source\repos\Hospite\Hospite\Views\Dashboard\ViewVisitors.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SignOutViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
