   M S B A M L   `   `   `  ����R  NAplicacionEscritorioWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AplicacionEscritorioWPFAplicacionEscritorioWPF  5   	   #    AplicacionEscritorioWPF.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:AplicacionEscritorioWPF     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Inicio de sesión��5	   	   $	��600��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�6;    � WindowStyle$ ThreeDBorderWindow=�6`    � 
ResizeMode$ CanMinimize=�6�   .��5
      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$ 0.9,1&�63   .��5      �  � Color$ 
DodgerBlue��6    � Offset$ 1Q�62   � 5      $ BlanchedAlmond��6   $ 0Q�66   5      .+�5   
   �� -   5        $	��500��5      $	��Top=�6    �� CornerRadius$ 	0 0 180 0��66   
�������5      �� 5   
   	 �� Orientation$	 Vertical=�6   .+�5      �� $	��350��6   .+�5      �� $!��/Recursos/img/img_logo2.png��6   $	��220��6=   $��40q�6I   5      �� 5      $	��350��6   .+�5      �� $��
Bienvenido��6   $��40(�6.   $��Calibri Light)�6<   
 �� TextAlignment$
 Center=�6W   $��0 -10 -20 0q�6n   
�������6�   �� 5      $	 
Horizontal=�6   $��	20 30 0 0q�66   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�6.   $��30��6:   $��30��6E   
������6Q   �� 5      -   5         ��Name$ txtUser��5      $��18(�6/   $��Calibri Light)�6=   $��10 0 0 0q�6X   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuario��6j   $	��300��6�   
�������.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 ����6�   5      �� 5      $	 
Horizontal=�6   $��	20 20 0 0q�66   .+�5        $
 Lock=�6.   $��30��6:   $��30��6E   
������6Q   G� 5       -   5         G�Name$ txtPass��5    "   $��18(�63   $��Calibri Light)�6A   $��10 0 0 0q�6\   $ Contraseña��6n   $	��300��6�   
�������
 ����6�   5!      �� 5"      $��	50 40 0 0q�6   $��Center=�60   .+�5#      �� -   5         ��Name$ btnLogin��5#      $	��150��6/   $��Calibri Light)�6;   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6V   
������
������� � ToolTip$ Login��6�   $��Ingresar��6�   $��21(�6�   
������5$      5%      5&      5'      5(      5)      