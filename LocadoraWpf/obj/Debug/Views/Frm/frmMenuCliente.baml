   M S B A M L   `   `   `  ����F  BLocadoraWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:LocadoraWpf.Views.FrmLocadoraWpf.Views.Frm  5   	   *    $LocadoraWpf.Views.Frm.frmMenuCliente   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:LocadoraWpf.Views.Frm     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��pgLoad��5   	   $	��600��5      $
��1080��6'   
���   �  � 
ResizeMode$  NoResize=�6G    � WindowStartupLocation$ CenterScreen=�6]    � WindowStyle$
 None=�6�    � 	Resources 5	         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �     �� 5
   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 70Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 ButtonOpenMenu��66   .[�5      �� #��[  6   5      :� 5   
   $	 ButtonBase.Click��6   $
 ButtonCloseMenu��66   .[�5      �� #��[ 6   5      .��5      � ���	#FFDEDEDE.+�5    
   � -   5         �Name$ GridMain��5       $��Right=�6!   $��Bottom=�6=   $	��540��6X   $
��1010��6e   .+�5"      �� $��/Assets/teste3.jpg��6   $	��578��60   $	��Top=�6=   $��-144,0,-130,-38q�6U    J� RenderTransformOrigin$ 0.5,0.5&�6n    J� OpacityMask
 �   �6�   � 5#      5$      � 5'   
   $��60��6   $	��Top=�6   ��5(      
� 5)      .��5*      �  � Color$ 	#FF474747��6#   � 5+      $ 	#FFB6B6B6��6#    � Offset$ 0.552Q�65   � 5,      $ 	#FF232323��6#   $ 0.978Q�65   5-       J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�52      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�53      �� $��Center=�6   $��16(�67   $
��Bold"�6E   �� 6X   $�Configurações��6\   �� 6s   �� 6   6�   '  !MaterialDesignThemes.Wpf.PopupBox  54         PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen .  $��10q�6e      PopupContent. 55      �� $	��150��6!   .+�56      �� -   5        $��btnAlterarDados��56   !   $��Alterar Dados��68   6P   �� 57      -   5        $��btnExcluirConta��57   !   $��Excluir Conta��68   6P   �� 58      �� 59      -   5        $��	btnLogout��59   !   $��Logout��62   6C   5:      5;      5<      �� 5=      $��Center=�6   $��Center=�65   $��36(�6P   $��425,0,363,-36q�6^   $
��Bold"�6u   $	��292��6�   $��	Underline{�6�   �� 6�   $�Menu do Cliente��6�   �� 6�   �� 6�   6�   5>      � 5?   
   -   5        $ GridMenu��5?      $��70��6!   $
��Left=�6,   ��5@      �� 5A       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5B      � $ 	#FF000078��6#   $
 0.07Q�65   � 5C      $ Black��6#   $ 0.991Q�61   � 5D      $ 	#FF000078��6#   $ 0.304Q�65   � 5E      $ 	#FF00005D��6#   $ 0.661Q�65   � 5F      $ Black��6#   $ 0.513Q�61   � 5G      $ Black��6#   $ 0.157Q�61   � 5H      $ Black��6#   � 5I      $ 	#FE000000��6#   $	 0.8Q�65   � 5J      $ 	#FE00003C��6#   $ 0.904Q�65   5K       5M        5N      $ 2Q�6#   $ 1Q�62   $ 	#FFAEAEAE��6B   .+�5P      �� .+�5Q      � $	��150��6   
�������$ 0.5,0.5&�67   z�5R      V� 5S      .~�5T      �� �� 5U      �� 5V      T� 5W      5X      .+�5Z      �� -   5         ��Name$ ButtonOpenMenu��5Z      $
��Auto��65   $��60��6C   $��0,5,5,85q�6N   $��Right=�6`    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6|   ���	#FF31577E��6�   Z� ��5[      �� 5\      $ 0.5,1&�62   $ 0.5,0&�6C   .��5]   "   � $ Black��6/   $ 0Q�6=   � 5^   "   $ Black��6/   $ 1Q�6=   5_      .��5b      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$
 Menu=�62   $��25��6>   $��25��6I   5c      �� 5d      -   5        $ ButtonCloseMenu��5d      $y�	Collapsed=�66   $��60��6M   $��60��6Y   $��5q�6d   $��Right=�6o   $	��Top=�6�   #��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5e        $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5f      �� 5h      $��80��6   $��Bottom=�6(   5i      �� 5j      -	   5         ��Name$ ListViewMenu��5j      ���	#FF5C99D6$��Disabled=�6H   .@�5l      �� -
   5         ��Name$ AlugarCarro��5l   #   $��60��68   .��5m      �� $ 
Horizontal=�6%   .+�5n        $	 Car=�66   $��25��6A   $��25��6M   $��10q�6X   �� 5o      $��Reservar Carro��6(   $��Center=�6>   $��20 10q�6Y   5p      5q      �� 5r      -   5        $ 
AlugarMoto��5r   #   $��83��67   .��5s      �� $ 
Horizontal=�6%   .+�5t        $ 
Motorcycle=�66   $��25��6H   $��25��6T   $��10q�6_   �� 5u      $��Reservar Moto��6(   $��Center=�6=   $��20 10q�6X   5v      5w      �� 5x      -   5        $ 	Devolucao��5x   #   $��83��66   .��5y      �� $ 
Horizontal=�6%   .+�5z        $ AssignmentReturn=�66   $��25��6N   $��25��6Z   $��10q�6e   �� 5{      $��Devolução��6(   $��Center=�69   $��20 10q�6T   5|      5}      5      5�      5�      5�      5�      