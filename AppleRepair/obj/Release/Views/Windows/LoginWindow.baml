   M S B A M L   `   `   `  ���� F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppleRepair.Views.WindowsAppleRepair.Views.Windows  +    %AppleRepair.Views.Windows.LoginWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:AppleRepair.Views.Windows     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���     MaterialDesignPaper#���    � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=�$��20(� � Title$* $RepairApple | Авторизация��$	��494��$	��629�� � Icon$+ %/Resources/Images/Repair-garden_2.ico����:  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .���  � ColumnDefinitions �� $
��168* ��� $
��239* �.+��� $ ��/Resources/Images/logo.png��$��
10,10,10,0q�$	��150��$	��Top=�$��Uniform=�$��1���� $��
5,170,5,60q�.+��� $��Авторизация��
���iii�$��20(�$��Center=�$
��0,20q�� $��0,5,0,0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  ���#29B6F6   Kind$ AccountOutline=�$��5q�$��30��$��30���� $��	40,5,10,0q� �� TextWrapping$
 Wrap=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��$��Stretch=�$	��Top=� � Cursor$ IBeam������ *Login+� .+�  ���#29B6F6$ PasswordOutline=�$��5q�$��30��$��30���� $��	40,5,10,0q�$
 Wrap=�$ Пароль��$��Stretch=�$	��Top=�$ IBeam������ *
Password+�� -   	 ��Name$	 LoginButton��$��
Войти��$��0,0,0,10q�$��0��
�������$��Center=�$��Bottom=�$	��230��$��1��$
 Hand��{��� *IsBtnEnabled+�� $,��&/Resources/Images/apple_background.png��$��1��$��Center=�$��Stretch=�$��UniformToFill=�$��0,0,0,0q��� $��1��$��Center=�$��0,47,0,0q�$
��Wrap=�
�������$��25(�$&�� Добро пожаловать!��$	��Top=�