   M S B A M L   `   `   `  ����F  BLocadoraWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:LocadoraWpf.Views.ControlsLocadoraWpf.Views.Controls  5      /    )LocadoraWpf.Views.Controls.usListaCliente   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:LocadoraWpf.Views.Controls     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � -   5        $��GridMainListaCliente��5
      $��
0,0,-180,0q�6'     � ColumnDefinitions  5   
   �� 5      $
��183* �6   �� 5      $
��797* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ Black��6   $ 1Q�6-   � 5      $ 	#FFAEAEAE��6   $ 0.501Q�61   5      .+�5   
   �� -   5         ��Name$ 	btnEditar��5      $��25,10,0,395q�6$   $
��Auto��69   $
��Left=�6G   $��50��6b   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5      $ Black��6#   $ 1Q�61   � 5      $
 Cyan��6#   $ 0.501Q�60   5      5      '  !MaterialDesignThemes.Wpf.PackIcon  5   
   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$
 Edit=�6"   $��27��6.   $��30��6:   $��	35,21,0,0q�6E   �� 5    
   -   5        $ 
btnExcluir��5       $��98,10,0,395q�6%   $
��Auto��6:   $
��Left=�6H   $��50��6c   ��5!      �� 5"      $ 0.5,1&�6&   $ 0.5,0&�67   .��5#      � $ Black��6#   $ 0Q�61   � 5$      $ Black��6#   $ 1Q�61   � 5%      $	 Red��6#   $ 0.501Q�6/   5&      5(        5)   
   $ Delete=�6"   $��27��60   $��27��6<   $��
109,21,0,0q�6G    J� RenderTransformOrigin$ 
0.25,0.278&�6[   �� 5*   
   -   5        $��btnPesquisa��5*      $
��Left=�6$   $��
648,10,0,0q�6?   $	��Top=�6S   $��63��6k   $��29��6v   $ 0.525,0.318&�6�   $��1��6�   ��5+      �� 5,      $ 0.5,1&�6&   $ 0.5,0&�67   .��5-      � $ Black��6#   $ 0Q�61   � 5.      $ 	#FF020202��6#   $ 1Q�65   � 5/      $ White��6#   $ 0.511Q�61   50      52      �� 53   
   -   5        $��txtPesquisa��53      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Nome��6%   
�������$
��Left=�6_   $��29��6z   $��
473,10,0,0q�6�   	 �� TextWrapping$
	 Wrap=�6�   $	��Top=�6�   $	��170��6�   $��1��6�   � 54   
   .+�55        $ Search=�6&   $��28��64   $��32��6@   $��883,12,-732,0q�6K   $ 0.781,0.719&�6b   56      &   System.Windows.Controls.DataGrid  57   
   -   5        $��ListagemCliente��57      $
��Left=�6*   $	��450��6E   $��10,55,0,-55q�6R   $	��Top=�6g   $	��966��6   
   AlternatingRowBackground

 ����� �� AlternationCount$ 2��6�      SelectionMode$ Single=�58         RowDetailsVisibilityMode$ 	Collapsed=�6*      GridLinesVisibility$ 
Horizontal=�6O      HeadersVisibility$ Column=�6p    � UseLayoutRounding .  $��10,0,0,0q�6�   $��2��6�      Columns 5:      9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	IdCliente+6Z     5<      $
 Nome��6U    6<   �� *Nome+6U     5=      $ Status��6W    6<   �� *Status+6W     5>      $ RG��6S    6<   �� *Rg+6S     5?      $	 CPF��6T    6<   �� *Cpf+6T     5@      $	 CNH��6T    6<   �� *Cnh+6T     5A      $ Categoria CNH��6]    6<   �� *CategoriaCnh+6]     5B      $	 Rua��6]    6<   �� *Endereco.Rua+6]     5C      $ Bairro��6`    6<   �� *Endereco.Bairro+6`     5D      $ Numero��6`    6<   �� *Endereco.Numero+6`     5E      $ Cidade��6`    6<   �� *Endereco.Cidade+6`     5F      $ Estado��6`    6<   �� *Endereco.Estado+6`   5K      5L      5N      