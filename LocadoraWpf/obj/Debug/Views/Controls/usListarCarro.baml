   M S B A M L   `   `   `  ����F  BLocadoraWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:LocadoraWpf.Views.ControlsLocadoraWpf.Views.Controls  5      .    (LocadoraWpf.Views.Controls.usListarCarro   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:LocadoraWpf.Views.Controls     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � -   5        $��GridMainListarCarro��5
      $��
0,0,-180,0q�6&   ��5   
   �� 5        �� EndPoint$  0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ Black��6   $ 0.997Q�6-   � 5      $ 	#FFAEAEAE��6   $ 0.501Q�61   5      .+�5   
   �� -   5        $��btnEditarCarro��5      $��25,10,0,395q�6'   $
��Auto��6<   $
��Left=�6J   $��50��6e   ��5      �� 5      $  0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5      $ Black��6#   $ 1Q�61   � 5      $ 	#FF00FDFD��6#   $ 0.501Q�65   5      5      '  !MaterialDesignThemes.Wpf.PackIcon  5   
   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$
 Edit=�6"   $��27��6.   $��30��6:   $��	35,21,0,0q�6E   �� 5   
   -   5        $��btnExcluirCarro��5      $��98,10,0,395q�6(   $
��Auto��6=   $
��Left=�6K   $��50��6f   ��5      �� 5      $  0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5       $ Black��6#   $ 1Q�61   � 5!      $	 Red��6#   $ 0.501Q�6/   5"      5$        5%   
   $ Delete=�6"   $��27��60   $��27��6<   $��
109,21,0,0q�6G    J� RenderTransformOrigin$ 
0.25,0.278&�6[   &   System.Windows.Controls.DataGrid  5&   
   -   5        $��ListagemCarros��5&      $
��Left=�6)   $	��450��6D   $��10,55,0,-55q�6Q   $	��Top=�6f   $	��966��6~      AlternatingRowBackground
 ����� �� AlternationCount$ 2��6�      SelectionMode$ Single=�5'      	   RowDetailsVisibilityMode$	 	Collapsed=�6*   
   GridLinesVisibility$
 
Horizontal=�6O      HeadersVisibility$ Column=�6p    � UseLayoutRounding .  $��10,0,0,0q�6�      Columns 5(      9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	IdVeiculo+6Z     5*      $
 Nome��6U    6<   �� *Nome+6U     5+      $ Modelo��6V    6<   �� *Marca+6V     5,      $	 Cor��6T    6<   �� *Cor+6T     5-      $	 Ano��6T    6<   �� *Ano+6T     5.      $ Placa��6V    6<   �� *Placa+6V     5/      $ Valor Por Dia��6m    6<   �� *ValorPorDia+ �� StringFormat$ C2��6m     50      $ Valor Por Hora��6n    6<   �� *ValorPorHora+$ C2��6n     51      $ Status��6W    6<   �� *Status+6W   56      �� 58   
   -   5        $��txtPesquisa��58      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Placa��6%   
�������$
��Left=�6`   $��29��6{   $��
685,10,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��170��6�   �� 5:   
   -   5        $��btnPesquisa��5:      $
��Left=�6%   $��
860,10,0,0q�6@   $	��Top=�6T   $��63��6l   $��29��6w   $ 0.525,0.318&�6�   ��5;      �� 5<      $  0.5,1&�6&   $ 0.5,0&�67   .��5=      � $ Black��6#   $ 0Q�61   � 5>      $ 	#FF020202��6#   $ 1Q�65   � 5?      $ White��6#   $ 0.511Q�61   5@      5B      � 5C   
   .+�5D        $ Search=�6&   $��28��64   $��32��6@   $��
876,10,0,0q�6K   $ 0.781,0.719&�6_   5E      5F      5G      