   M S B A M L   `   `   `  ����B  >PERform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PERformPERform  5   	       PERform.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   !localclr-namespace:PERform  5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5
   	   $	��600��6   $	��800��6)   .��5      )  #MaterialDesignThemes.Wpf.DrawerHost  -   5          Name$ 
DrawerHost��5          IsLeftDrawerOpen 64   �� *IsLeftDrawerOpen+   LeftDrawerContent 5   
   ]� 5      $	��200��6   ��.  .+�5      d�    CloseDrawerCommand#��Z 6    '  #MaterialDesignHamburgerToggleButton#��[  6a   $��Right=�6�   $��15q�6�   $	��Top=�6	   d� 	IsChecked 6�   ��  �� ElementName$ 
DrawerHost�� �� Path$ IsLeftDrawerOpen�6	  �� 5      $
��Home��6     MaterialDesignFlatButton#���  6(   $
��Home��6x   $	��Top=�6�   ��6[   �� *
PageOpen+6�   �� 5      $��Modifier��6   #���  6,   $��Modifier��6|   $	��Top=�6�   ��6_   �� *
PageOpen+6�   �� 5      $��Checker��6   #���  6+   {�.  $��Checker��6�   $	��Top=�6�   ��6p   �� *
PageOpen+6�   �� 5      $��Parser��6   #���  6*   {�.  $��Parser��6�   $	��Top=�6�   ��6o   �� *
PageOpen+6�   �� 5      $��Snippets��6   #���  6,   $��Snippets��6|   $	��Top=�6�   ��6_   �� *
PageOpen+6�   �� 5      $��	About DEV��6   #���  6-   {�.  $��AboutDEV��6�   $��0,0,0,15q�6�   $��Bottom=�6�   ��6r   �� *
PageOpen+6�   5      .��5   
   ]� .+�5      (  "MaterialDesignThemes.Wpf.ColorZone  $��15q�6'   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�64   	   Mode$	 
PrimaryMid=�6e   $	��Top=�6x   .��5      ]� .+�5      d� -   5        
 d�Name$
 MenuToggleButton��5   #      OpenDrawerCommand#��Z 6=   #��[  6~    6�   �� $ 
DrawerHost��$ IsLeftDrawerOpen��� 5      $��22(�6    $��PERform��6.   $��Center=�6=   $��Center=�6Z   '  !MaterialDesignThemes.Wpf.PopupBox  5         	StaysOpen . $��Center=�6?   $��Right=�6Z      PlacementMode$ LeftAndAlignTopEdges=�6q      PopupContent. 5      ��  �� Padding$ 10q�6!   ._�5      �� .+�5    "   ��  �� Orientation$ 
Horizontal=�6-   .+�5!   &   �� $%��Create backup of modified files��6/    � ToolTip$V PIf checked, backup of modified files will be created and stored in Backup folder��6Y   5"   #   5#      5$      5%      �� 5&      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ .ph file��6;      
IsFloating . $	��150��6�   $��Center=�6�   $��Right=�6�   ��6   �� *TextBoxText+.��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5'      /  )System.Windows.Interactivity.EventTrigger  5(         	EventName$ PreviewMouseDown��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5)   "   6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 68   �� *	MouseDown+5*      .��5+   2   5,      '
  !MaterialDesignThemes.Wpf.PackIcon
  5-      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 File=�6.   $��Right=�6:   $��Center=�6V   $��5q�6q   $��20��6|   $��20��6�   $��Right=�6�   5.      5/      �� 50      ��6   �� *PageContent+ �� Mode$ OneWay=�51      52      53      