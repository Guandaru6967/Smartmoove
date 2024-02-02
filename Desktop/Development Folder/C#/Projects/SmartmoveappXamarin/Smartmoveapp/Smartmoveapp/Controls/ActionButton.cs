using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Smartmoveapp.Controls
{
          public partial class ActionButton : ActionItem
          {
                    public List<ActionItem> ActionButtons { get; set; }

                    public bool State { get; set; } = false;

                    public StackLayout View { get; set; }
                    public BindableProperty ViewProperty = BindableProperty.Create(nameof(View), typeof(string), typeof(ActionButton), null);


                    void ViewOnChildAdded(object sender, ElementEventArgs args)
                    {

                              if (args.Element.GetType() == typeof(Grid))
                              {
                                        this.BackgroundColor = Color.Yellow;
                                        if (this.FindByName("ActionList") != null)
                                        {
                                                  View = (StackLayout)this.FindByName("ActionList");
                                                  foreach (ActionItem actionbutton in View.Children)
                                                  {
                                                            ActionButtons.Add(actionbutton);
                                                  }
                                        }
                              }
                              else if (args.Element.GetType() == typeof(Button))
                              {
                                        this.BackgroundColor = Color.Red;
                              }
                    }

                    public void AddChildren(ActionItem Button)
                    {

                              this.ActionButtons.Add(Button);
                              if (View == null)
                              {
                                        ((Grid)this.FindByName("ActionList")).Children.Add(Button);
                                        View = ((StackLayout)this.FindByName("ActionList"));
                              }
                    }


                    void Open()
                    {
                              var ActionLayout = ((StackLayout)this.FindByName("ActionList"));

                              foreach (var button in ActionLayout.Children)
                              {
                                        if (button.GetType() == typeof(ActionItem))
                                        {

                                                  button.IsVisible = true;

                                                  //Debug.WriteLine(((StackLayout)this.FindByName("ActionList")).Children.IndexOf(button));
                                                  button.TranslateTo(0, -ActionLayout.Children.IndexOf(button) * ((ActionItem)button).ButtonSize * 2.25 + 50, 300, Easing.CubicIn);

                                                  //button.TranslateTo(0, -((ActionItem)button).ButtonSize, 100, Easing.CubicIn);
                                                  //((StackLayout)this.FindByName("ActionList")).HeightRequest = ((StackLayout)this.FindByName("ActionList")).Children.Count* ((ActionItem)button).ButtonSize;
                                                  //((ActionItem)button).Margin=new Thickness(0,0,0, ((ActionItem)button).ButtonSize* ((StackLayout)this.FindByName("ActionList")).Children.IndexOf(button));

                                                  ((ActionItem)button).Open();

                                                  //new StackLayout().GestureRecognizers.Add(new GestureRecognizer());
                                        }
                              }
                        ((Button)ActionLayout.Children.Last()).Text = "close";
                              State = true;
                    }

                    public void Close()
                    {
                              var ActionLayout = ((StackLayout)this.FindByName("ActionList"));
                              foreach (var button in ActionLayout.Children)
                              {

                                        if (button.GetType() == typeof(ActionItem))
                                        {
                                                  button.TranslateTo(0, ActionLayout.Children.IndexOf(button) * ((ActionItem)button).ButtonSize * 2.25 + 50, 250, Easing.CubicOut);
                                                  button.IsVisible = false;
                                                  //((ActionItem)button).Margin = new Thickness(0);
                                                  ((ActionItem)button).Close();
                                        }
                              }
                       ((Button)ActionLayout.Children.Last()).Text = "add";
                              State = false;
                    }
                    public void Toggle()
                    {
                              if (this.State)
                              {

                                        Close();
                              }
                              else
                              {

                                        Open();
                              }

                    }

          }
}
