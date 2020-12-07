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

        public static IServiceCollection AddBlamanticUI(this IServiceCollection services)
        {
            services.AddBUI();
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
                .AddNavigation("Element", nav =>
                {
                    AddElement(nav);
                })
                .AddNavigation("Component", nav =>
                {
                    AddComponent(nav);
                })
                .AddNavigation("Service", nav =>
                {
                    AddService(nav);
                })
                ;

            return services;
        }

        private static void AddService(ICollection<Navigation> nav)
        {
            nav.Add(new Navigation
            {
                Name = "对话框(Dialog)",
                Link = "/service/dialog"
            });
            nav.Add(new Navigation
            {
                Name = "事件通知(Toast)",
                Link = "/service/toast"
            });
        }

        private static void AddComponent(ICollection<Navigation> nav)
        {
            nav.Add(new Navigation
            {
                Name = "下拉菜单(Dropdown)",
                Link = "/component/dropdown"
            });
            nav.Add(new Navigation
            {
                Name = "表单(Form)",
                Link = "/component/form"
            });
            nav.Add(new Navigation
            {
                Name = "模态框(Modal)",
                Link = "/component/modal"
            });
            nav.Add(new Navigation
            {
                Name = "导航菜单(NavMenu)",
                Link = "/component/nav"
            });
            nav.Add(new Navigation
            {
                Name = "分页(Pagination)",
                Link = "/component/pagination"
            });
            nav.Add(new Navigation
            {
                Name = "进度条(ProgressBar)",
                Link = "/component/progress"
            });
            nav.Add(new Navigation
            {
                Name = "选项卡(Tab)",
                Link = "/component/tab"
            });
        }

        private static void AddElement(ICollection<Navigation> nav)
        {
            nav.Add(new Navigation
            {
                Name = "按钮(Button)",
                Link = "/element/button"
            });
            nav.Add(new Navigation
            {
                Name = "卡片(Card)",
                Link = "/element/card"
            });
            nav.Add(new Navigation
            {
                Name = "容器(Container)",
                Link = "/element/container"
            });
            nav.Add(new Navigation
            {
                Name = "遮罩层(Dimmer)",
                Link = "/element/dimmer"
            });
            nav.Add(new Navigation
            {
                Name = "分割线(Divider)",
                Link = "/element/divider"
            });
            nav.Add(new Navigation
            {
                Name = "旗帜(Flag)",
                Link = "/element/flag"
            });
            nav.Add(new Navigation
            {
                Name = "栅格(Grid)",
                Link = "/element/grid"
            });
            nav.Add(new Navigation
            {
                Name = "标题(Header)",
                Link = "/element/header"
            });
            nav.Add(new Navigation
            {
                Name = "图标(Icon)",
                Link = "/element/icon"
            });
            nav.Add(new Navigation
            {
                Name = "图像(Image)",
                Link = "/element/image"
            });
            nav.Add(new Navigation
            {
                Name = "项目列表(ItemList)",
                Link = "/element/itemlist"
            });
            nav.Add(new Navigation
            {
                Name = "输入盒(InputBox)",
                Link = "/element/input"
            });
            nav.Add(new Navigation
            {
                Name = "标签(Label)",
                Link = "/element/label"
            });
            nav.Add(new Navigation
            {
                Name = "列表(List)",
                Link = "/element/list"
            });
            nav.Add(new Navigation
            {
                Name = "加载器(Loader)",
                Link = "/element/loader"
            });
            nav.Add(new Navigation
            {
                Name = "菜单(Menu)",
                Link = "/element/menu"
            });
            nav.Add(new Navigation
            {
                Name = "消息(Message)",
                Link = "/element/message"
            });
            nav.Add(new Navigation
            {
                Name = "片段(Segment)",
                Link = "/element/segment"
            });
            nav.Add(new Navigation
            {
                Name = "表格(Table)",
                Link = "/element/table"
            });
            nav.Add(new Navigation
            {
                Name = "文本(Text)",
                Link = "/element/text"
            });
        }
    }
}
