   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppleRepair.Views.WindowsAppleRepair.Views.Windows  5   	   +    %AppleRepair.Views.Windows.LoginWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppleRepair.Views.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $��20(�5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64f6  0MaterialDesignExtensions.Controls.MaterialWindow   BorderBackgroundBrush �#2196F3 � Title$1 +APPLE СЕРВИС | Авторизация��5   	   $	��494��6,   $	��629��69    � Icon$  /Resources/Images/icon.ico��6E    �� BitmapScalingMode$ HighQuality=�6g   ��5
   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  � ColumnDefinitions 5   
   �� 5      $
��168* �6   �� 5      $
��239* �6   .+�5   
   �� $ HighQuality=�6   $ ��/Resources/Images/logo.png��6>   $��
10,10,10,0q�6b   $	��150��6v   $	��Top=�6�   $��Uniform=�6�   $��1��6�   �� 5   
   $��
5,170,5,60q�6   .+�5      �� $��Авторизация��6   
���iii�$��20(�6@   $��Center=�6N   $
��0,20q�6k   � 5      $��0,5,0,0q�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  ���#29B6F6   Kind$ AccountOutline=�6?   $��5q�6U   $��30��6`   $��30��6k   �� 5      $��	40,5,10,0q�6    �� TextWrapping$
 Wrap=�6-   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 
Логин��6X   $��Stretch=�6   $	��Top=�6�   ��6A   �� *Login+6�   5      � 5       .+�5!        ���#29B6F6$ PasswordOutline=�6?   $��5q�6V   $��30��6a   $��30��6l   G� 5"      -   5        
 G�Name$
 passwordText��5"      $��	40,5,10,0q�64   $	 Пароль��6G   $��Stretch=�6o   $	��Top=�6�    � Cursor$ IBeam��6�   5#      5$      �� 5&   
   -   5         ��Name$ LoginButton��5&      $��
Войти��6&   $��0,0,0,10q�66   $��0��6H   
�������$��Center=�6�   $��Bottom=�6�   $	��230��6�   $��1��6�   $
 Hand��6   {�6k   �� *IsBtnEnabled+6   �� 5'   
   $,��&/Resources/Images/apple_background.png��6   $��1��6@   $��Center=�6P   $��Stretch=�6m   $��UniformToFill=�6�   $��0,0,0,0q�6�   �� 5(   
   $��1��6   $��Center=�6$   $��0,47,0,0q�6A   $
��Wrap=�6S   
�������$��25(�6z   $&�� Добро пожаловать!��6�   $	��Top=�6�   5)      5*      