using System;
using System.Collections.Generic;
using Markdig;
using Markdig.SyntaxHighlighting;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace BlamanticUI.Shared
{
    public static class Code
    {
        public const string TITLE = "Blamantic-UI";
        public static MarkupString GetCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value cannot be null or white space", nameof(value));
            }

            return new MarkupString(Markdown.ToHtml(value, new MarkdownPipelineBuilder().UseAdvancedExtensions().UseSyntaxHighlighting().Build()));
        }

        public static string GetVersion(bool full = false)
        {
            var version = typeof(BlamanticUI.Abstractions.BlamanticComponentBase).Assembly.GetName().Version;
            if (version == null)
            {
                return string.Empty;
            }
            if (full)
            {
                return version.ToString();
            }
            return $"{version.Major}.{version.Minor}.{version.Build}";
        }

        public static IServiceCollection AddDemo(this IServiceCollection services)
        {
            DependencyInjectionExtensions.AddBlamanticUI(services);
            services.AddNavigation(nav =>
            {
                nav.Add(new Navigation
                {
                    Name = "首页",
                    Link = "/",
                    IconClass = "home"
                });

                nav.Add(new Navigation
                {
                    Name = "新闻",
                    Navigations = new List<Navigation> {
                        new Navigation
                        {
                             Name="国内"
                        },
                        new Navigation
                        {
                            Name="国际"
                        },
                        new Navigation
                        {
                            Name="娱乐",
                            Navigations=new List<Navigation>
                            {
                                new Navigation
                                {
                                     Name="内地"
                                },
                                new Navigation
                                {
                                    Name="港台"
                                },
                            }
                        }
                    }
                });

            });
            services.AddNavigation("Game", nav =>
            {
                nav.Add(new Navigation
                {
                    Name = "游戏",
                    IconClass = "game",
                    Navigations = new List<Navigation> {
                        new Navigation
                        {
                             Name="网游"
                        },
                        new Navigation
                        {
                            Name="手游"
                        },
                     }
                });
                nav.Add(new Navigation
                {
                    Name = "合作伙伴",
                    IconClass = "users"
                });
            });
            services.AddNavigation("Sports", nav =>
            {
                nav.Add(new Navigation
                {
                    Name = "NBA"
                });
                nav.Add(new Navigation
                {
                    Name = "CBA"
                });
                nav.Add(new Navigation
                {
                    Name = "FIBA"
                });
            });

            services
                .AddNavigation("Common", AddCommon)
                .AddNavigation("Input", AddInput)
                .AddNavigation("Layout", AddLayout)
                .AddNavigation("Data", AddData)
                .AddNavigation("Feedback", AddFeedback)
                .AddNavigation("Nav", AddNav)
            ;

            return services;
        }


        static void AddCommon(ICollection<Navigation> nav)
        {
            string prefix = "common";
            nav.Add(new Navigation
            {
                Name = "按钮(Button)",
                Link = $"/component/{prefix}/button"
            });

            nav.Add(new Navigation
            {
                Name = "图标(Icon)",
                Link = $"/component/{prefix}/icon"
            });

            nav.Add(new Navigation
            {
                Name = "图像(Image)",
                Link = $"/component/{prefix}/image"
            });
            nav.Add(new Navigation
            {
                Name = "旗帜(Flag)",
                Link = $"/component/{prefix}/flag"
            });
            nav.Add(new Navigation
            {
                Name = "标签(Label)",
                Link = $"/component/{prefix}/label"
            });
            nav.Add(new Navigation
            {
                Name = "文本(Text)",
                Link = $"/component/{prefix}/text"
            });
            nav.Add(new Navigation
            {
                Name = "片段(Segment)",
                Link = $"/component/{prefix}/segment"
            });
        }

        static void AddInput(ICollection<Navigation> nav)
        {
            string prefix = "input";
            nav.Add(new Navigation
            {
                Name = "表单(Form)",
                Link = $"/component/{prefix}/form"
            });
            nav.Add(new Navigation
            {
                Name = "文本域(TextField)",
                Link = $"/component/{prefix}/textfield"
            });
            nav.Add(new Navigation
            {
                Name = "单/复选(CheckBox)",
                Link = $"/component/{prefix}/checkbox"
            });
            nav.Add(new Navigation
            {
                Name = "下拉列表(DropdownList)",
                Link = $"/component/{prefix}/dropdown"
            });
            nav.Add(new Navigation
            {
                Name = "日历(Calendar)",
                Link = $"/component/{prefix}/calendar"
            });
        }

        static void AddLayout(ICollection<Navigation> nav)
        {
            string prefix = "layout";
            nav.Add(new Navigation
            {
                Name = "栅格(Grid)",
                Link = $"/component/{prefix}/grid"
            });

            nav.Add(new Navigation
            {
                Name = "容器(Container)",
                Link = $"/component/{prefix}/container"
            });

            nav.Add(new Navigation
            {
                Name = "卡片(Card)",
                Link = $"/component/{prefix}/card"
            });
            nav.Add(new Navigation
            {
                Name = "分割线(Divider)",
                Link = $"/component/{prefix}/divider"
            });
            nav.Add(new Navigation
            {
                Name = "标题(Header)",
                Link = $"/component/{prefix}/header"
            });
            nav.Add(new Navigation
            {
                Name = "项目列表(ItemList)",
                Link = $"/component/{prefix}/itemlist"
            });
            nav.Add(new Navigation
            {
                Name = "列表(List)",
                Link = $"/component/{prefix}/list"
            });
            nav.Add(new Navigation
            {
                Name = "选项卡(Tab)",
                Link = $"/component/{prefix}/tab"
            });
            nav.Add(new Navigation
            {
                Name = "菜单(Menu)",
                Link = $"/component/{prefix}/menu"
            });
        }

        static void AddData(ICollection<Navigation> nav)
        {
            string prefix = "data";
            nav.Add(new Navigation
            {
                Name = "表格(Table)",
                Link = $"/component/{prefix}/table"
            });
            nav.Add(new Navigation
            {
                Name = "分页(Pagination)",
                Link = $"/component/{prefix}/pagination"
            });
            nav.Add(new Navigation
            {
                Name = "手风琴(Accordion)",
                Link = $"/component/{prefix}/accordion"
            });
        }

        static void AddFeedback(ICollection<Navigation> nav)
        {
            string prefix = "feedback";
            nav.Add(new Navigation
            {
                Name = "模态框(Modal)",
                Link = $"/component/{prefix}/modal"
            });
            nav.Add(new Navigation
            {
                Name = "进度条(ProgressBar)",
                Link = $"/component/{prefix}/progress"
            });
            nav.Add(new Navigation
            {
                Name = "消息(Message)",
                Link = $"/component/{prefix}/message"
            });
            nav.Add(new Navigation
            {
                Name = "对话框(Dialog)",
                Link = $"/component/{prefix}/dialog"
            });
            nav.Add(new Navigation
            {
                Name = "消息通知(Toast)",
                Link = $"/component/{prefix}/toast"
            });
            nav.Add(new Navigation
            {
                Name = "遮罩层(Dimmer)",
                Link = $"/component/{prefix}/dimmer"
            });
            nav.Add(new Navigation
            {
                Name = "加载器(Loader)",
                Link = $"/component/{prefix}/loader"
            });
        }

        static void AddNav(ICollection<Navigation> nav)
        {
            string prefix = "nav";
            nav.Add(new Navigation
            {
                Name = "导航菜单(NavMenu)",
                Link = $"/component/{prefix}/navmenu"
            });
            nav.Add(new Navigation
            {
                Name = "步骤引导(Steps)",
                Link = $"/component/{prefix}/steps"
            });
        }
    }
}
