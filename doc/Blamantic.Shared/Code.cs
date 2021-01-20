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
            services.AddBlamanticUI();
            services.AddNavigation(nav =>
            {
                nav.Add(new Navigation
                {
                    Name = "Index",
                    Link = "/",
                    IconClass = "home"
                });

                nav.Add(new Navigation
                {
                    Name = "News",
                    Navigations = new List<Navigation> {
                        new Navigation
                        {
                             Name="National"
                        },
                        new Navigation
                        {
                            Name="International"
                        },
                        new Navigation
                        {
                            Name="Entertainment",
                            Navigations=new List<Navigation>
                            {
                                new Navigation
                                {
                                     Name="China"
                                },
                                new Navigation
                                {
                                    Name="USA"
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
                    Name = "Game",
                    IconClass = "game",
                    Navigations = new List<Navigation> {
                        new Navigation
                        {
                             Name="Web"
                        },
                        new Navigation
                        {
                            Name="Mobile"
                        },
                     }
                });
                nav.Add(new Navigation
                {
                    Name = "Conduct",
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
                Name = "Button",
                Link = $"/component/{prefix}/button"
            });

            nav.Add(new Navigation
            {
                Name = "Icon",
                Link = $"/component/{prefix}/icon"
            });

            nav.Add(new Navigation
            {
                Name = "Image",
                Link = $"/component/{prefix}/image"
            });
            nav.Add(new Navigation
            {
                Name = "Flag",
                Link = $"/component/{prefix}/flag"
            });
            nav.Add(new Navigation
            {
                Name = "Label",
                Link = $"/component/{prefix}/label"
            });
            nav.Add(new Navigation
            {
                Name = "Text",
                Link = $"/component/{prefix}/text"
            });
            nav.Add(new Navigation
            {
                Name = "Segment",
                Link = $"/component/{prefix}/segment"
            });
        }

        static void AddInput(ICollection<Navigation> nav)
        {
            string prefix = "input";
            nav.Add(new Navigation
            {
                Name = "Form",
                Link = $"/component/{prefix}/form"
            });
            nav.Add(new Navigation
            {
                Name = "TextField",
                Link = $"/component/{prefix}/textfield"
            });
            nav.Add(new Navigation
            {
                Name = "CheckBox",
                Link = $"/component/{prefix}/checkbox"
            });
            nav.Add(new Navigation
            {
                Name = "DropdownList",
                Link = $"/component/{prefix}/dropdown"
            });
            nav.Add(new Navigation
            {
                Name = "DateField",
                Link = $"/component/{prefix}/datefield"
            });
            nav.Add(new Navigation
            {
                Name = "Calendar",
                Link = $"/component/{prefix}/calendar"
            });
        }

        static void AddLayout(ICollection<Navigation> nav)
        {
            string prefix = "layout";
            nav.Add(new Navigation
            {
                Name = "Grid",
                Link = $"/component/{prefix}/grid"
            });

            nav.Add(new Navigation
            {
                Name = "Container",
                Link = $"/component/{prefix}/container"
            });

            nav.Add(new Navigation
            {
                Name = "Card",
                Link = $"/component/{prefix}/card"
            });
            nav.Add(new Navigation
            {
                Name = "Divider",
                Link = $"/component/{prefix}/divider"
            });
            nav.Add(new Navigation
            {
                Name = "Header",
                Link = $"/component/{prefix}/header"
            });
            nav.Add(new Navigation
            {
                Name = "ItemList",
                Link = $"/component/{prefix}/itemlist"
            });
            nav.Add(new Navigation
            {
                Name = "List",
                Link = $"/component/{prefix}/list"
            });
            nav.Add(new Navigation
            {
                Name = "Tab",
                Link = $"/component/{prefix}/tab"
            });
            nav.Add(new Navigation
            {
                Name = "Menu",
                Link = $"/component/{prefix}/menu"
            });
        }

        static void AddData(ICollection<Navigation> nav)
        {
            string prefix = "data";
            nav.Add(new Navigation
            {
                Name = "Table",
                Link = $"/component/{prefix}/table"
            });
            nav.Add(new Navigation
            {
                Name = "Pagination",
                Link = $"/component/{prefix}/pagination"
            });
            nav.Add(new Navigation
            {
                Name = "Accordion",
                Link = $"/component/{prefix}/accordion"
            });
        }

        static void AddFeedback(ICollection<Navigation> nav)
        {
            string prefix = "feedback";
            nav.Add(new Navigation
            {
                Name = "Modal",
                Link = $"/component/{prefix}/modal"
            });
            nav.Add(new Navigation
            {
                Name = "ProgressBar",
                Link = $"/component/{prefix}/progress"
            });
            nav.Add(new Navigation
            {
                Name = "Message",
                Link = $"/component/{prefix}/message"
            });
            nav.Add(new Navigation
            {
                Name = "Dialog",
                Link = $"/component/{prefix}/dialog"
            });
            nav.Add(new Navigation
            {
                Name = "Toast",
                Link = $"/component/{prefix}/toast"
            });
            nav.Add(new Navigation
            {
                Name = "Dimmer",
                Link = $"/component/{prefix}/dimmer"
            });
            nav.Add(new Navigation
            {
                Name = "Loader",
                Link = $"/component/{prefix}/loader"
            });
        }

        static void AddNav(ICollection<Navigation> nav)
        {
            string prefix = "nav";
            nav.Add(new Navigation
            {
                Name = "NavMenu",
                Link = $"/component/{prefix}/navmenu"
            });
            nav.Add(new Navigation
            {
                Name = "Step",
                Link = $"/component/{prefix}/steps"
            });
        }
    }
}
