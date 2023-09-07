using AdaptiveCards;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Schema.Teams;
using Microsoft.BotBuilderSamples.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.BotBuilderSamples.Helpers
{
    public class CardHelper
    {
        /**
        public static List<MessagingExtensionAttachment> CreateAdaptiveCardAttachment(MessagingExtensionAction action, CardResponse createCardResponse)
        {
            
            AdaptiveCard adaptiveCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0));
            adaptiveCard.Body = new List<AdaptiveElement>()
            {
                new AdaptiveColumnSet()
                {
                    Columns = new List<AdaptiveColumn>()
                    {
   
                        new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= "Name :",
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Medium,
                                    Weight=AdaptiveTextWeight.Bolder
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                         new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= "2003",
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Large,
                                    Weight=AdaptiveTextWeight.Default
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                    }
                },
                new AdaptiveColumnSet()
                {
                    Columns = new List<AdaptiveColumn>()
                    {
                        new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= "My current election Perks+",
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Medium,
                                    Weight=AdaptiveTextWeight.Bolder
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                        new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= createCardResponse.Subtitle,
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Medium,
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                    }
                },
                new AdaptiveColumnSet()
                {
                    Columns = new List<AdaptiveColumn>()
                    {
                        new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= "Description :",
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Medium,
                                    Weight=AdaptiveTextWeight.Bolder
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                         new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= createCardResponse.Text,
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Medium,
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                    }
                },
            };
            


            var attachments = new List<MessagingExtensionAttachment>();
            attachments.Add(new MessagingExtensionAttachment
            {
                Content = adaptiveCard,
                ContentType = AdaptiveCard.ContentType
            });

            return attachments;
        }
        */

        public static List<MessagingExtensionAttachment> CreateAdaptiveCardAttachment(MessagingExtensionAction action, CardResponse createCardResponse)
        {
            // combine path for cross platform support
            var paths = new[] { ".", "Resources", "adaptiveCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var attachments = new List<MessagingExtensionAttachment>();
            attachments.Add(new MessagingExtensionAttachment
            {
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
                ContentType = "application/vnd.microsoft.card.adaptive",
            });

            return attachments;
        }

        public static List<MessagingExtensionAttachment> CreateAdaptiveCardAttachmentForHTML(MessagingExtensionAction action, CardResponse createCardResponse)
        {
            AdaptiveCard adaptiveCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0));
            adaptiveCard.Body = new List<AdaptiveElement>()
            {
                new AdaptiveColumnSet()
                {
                    Columns = new List<AdaptiveColumn>()
                    {
                        new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= "User Name :",
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Medium,
                                    Weight=AdaptiveTextWeight.Bolder
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                         new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= createCardResponse.UserName,
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Medium,
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                    }
                },
                new AdaptiveColumnSet()
                {
                    Columns = new List<AdaptiveColumn>()
                    {
                        new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= "Password is :",
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Medium,
                                    Weight=AdaptiveTextWeight.Bolder
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                        new AdaptiveColumn()
                        {
                            Items=new List<AdaptiveElement>()
                            {
                                new AdaptiveTextBlock()
                                {
                                    Text= createCardResponse.UserPwd,
                                    Wrap=true,
                                    Size=AdaptiveTextSize.Medium,
                                }
                            },
                            Width = AdaptiveColumnWidth.Auto
                        },
                    }
                },
            };

            var attachments = new List<MessagingExtensionAttachment>();
            attachments.Add(new MessagingExtensionAttachment
            {
                Content = adaptiveCard,
                ContentType = AdaptiveCard.ContentType
            });

            return attachments;
        }
    }
}
