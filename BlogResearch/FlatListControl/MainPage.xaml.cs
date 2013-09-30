using System.Collections.Generic;

namespace FlatListControl
{
    public partial class MainPage
    {
        public class Node
        {
            public string Title { get; set; }
            public List<Node> Children { get; set; }
        }

        public List<Node> MasterList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            MasterList = new List<Node>
                {
                    new Node
                        {
                            Title = "Item 1",
                            Children = new List<Node>
                                {
                                    new Node { Title = "Subitem1" },
                                    new Node { Title = "Subitem2" },
                                    new Node { Title = "Subitem3" },
                                    new Node { Title = "Subitem4" }
                                }
                        },
                    new Node
                        {
                            Title = "Item 2",
                            Children = new List<Node>
                                {
                                    new Node { Title = "Subitem1" },
                                    new Node { Title = "Subitem2" },
                                    new Node { Title = "Subitem3" },
                                    new Node { Title = "Subitem4" }
                                }
                        },
                    new Node
                        {
                            Title = "Item 3",
                            Children = new List<Node>
                                {
                                    new Node { Title = "Subitem1" },
                                    new Node { Title = "Subitem2" },
                                    new Node { Title = "Subitem3" },
                                    new Node { Title = "Subitem4" }
                                }
                        }
                };

            DataContext = this;
        }
    }
}