   M S B A M L   `   `   `  ���� B  >PERform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PERformPERform      PERform.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  !localclr-namespace:PERform  U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
MainWindow��$	��600��$	��800��.��)  #MaterialDesignThemes.Wpf.DrawerHost  -     Name$ 
DrawerHost��   IsLeftDrawerOpen �� *IsLeftDrawerOpen+   LeftDrawerContent ]� $	��200����.  .+�d�    CloseDrawerCommand#��Z  '  #MaterialDesignHamburgerToggleButton#��[  $��Right=�$��15q�$	��Top=� d� 	IsChecked ��  �� ElementName$ 
DrawerHost�� �� Path$ IsLeftDrawerOpen��� $
��Home��  MaterialDesignFlatButton#���  $
��Home��$	��Top=����� *
PageOpen+�� $��Modifier��#���  $��Modifier��$	��Top=����� *
PageOpen+�� $��Checker��#���  {�.  $��Checker��$	��Top=����� *
PageOpen+�� $��Parser��#���  {�.  $��Parser��$	��Top=����� *
PageOpen+�� $��Snippets��#���  $��Snippets��$	��Top=����� *
PageOpen+�� $��	About DEV��#���  {�.  $��AboutDEV��$��0,0,0,15q�$��Bottom=����� *
PageOpen+.��]� .+�(  "MaterialDesignThemes.Wpf.ColorZone  $��15q�+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�	   Mode$	 
PrimaryMid=�$	��Top=�.��]� .+�d� -   
 d�Name$
 MenuToggleButton��   OpenDrawerCommand#��Z #��[   �� $ 
DrawerHost��$ IsLeftDrawerOpen��� $��22(�$��PERform��$��Center=�$��Center=�'  !MaterialDesignThemes.Wpf.PopupBox     	StaysOpen . $��Center=�$��Right=�   PlacementMode$ LeftAndAlignTopEdges=�   PopupContent. ��  �� Padding$ 10q�._��� .+���  �� Orientation$ 
Horizontal=�.+��� $%��Create backup of modified files�� � ToolTip$V PIf checked, backup of modified files will be created and stored in Backup folder���� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ .ph file��   
IsFloating . $	��150��$��Center=�$��Right=����� *TextBoxText+.��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ PreviewMouseDown��.  (System.Windows.Interactivity.TriggerBase   Actions. 6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command �� *	MouseDown+.��'
  !MaterialDesignThemes.Wpf.PackIcon
  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 File=�$��Right=�$��Center=�$��5q�$��20��$��20��$��Right=��� ���� *PageContent+ �� Mode$ OneWay=�