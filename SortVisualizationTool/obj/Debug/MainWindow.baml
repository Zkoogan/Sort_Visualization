   M S B A M L   `   `   `  ����P  LSortVisualizationTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SortVisualizationToolSortVisualizationTool  5   	   &     SortVisualizationTool.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SortVisualizationTool     5   	   U QMaterialDesignThemes.Wpf, Version=3.1.0.981, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1550��6)      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � WindowStyle$
 None=�68    � WindowStartupLocation$ CenterScreen=�6K    � 	Resources 5      )  #SortVisualizationTool.MainViewModel  mvm��%   &	         5   
   6   5      .��5      #  MaterialDesignThemes.Wpf.Card  .��5   
   �  � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��* �6   �� 5      $��4* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6#   �� 5      $��2* �6#   �� 5       $��2* �6   .+�5"      �� $��1��6   .+�5#      �� ��6   �� *Sorting_methods.Keys+ �� Source# [ 	 �� SelectedItem	 6e   �� *selectedSortingMethod+# [ �� 5$      
 �� Orientation$
 
Horizontal=�6   .+�5%      �� $��Antal Datapunkter: ��6    �� 5&       � Minimum$ 0Q�6    � Maximum$
 1400Q�6)   $	��200��6q    � Value 68   �� *	n_samples+# [ 6q   5'      5(      �� 5)      $��1��6_   $��2��6o   $��3��6�   ��6   �� *ListToBeSorted+# [ ��5*      �� 5+      .R�5,      �� $
 
Horizontal=�6!   $��Bottom=�6:   5-      ��5/      �� 51      .R�52      �� $��1��6   $y�Visible=�6@   $��Bottom=�6U   ��6'   �� *Value+��53      �� 54       �� 
TargetType" ��6$   .�55   "   ��  �� Property � �� �� Value
 �   �6?    �� Triggers 56   "   �� 57   &    �� Binding 62   �� *State+ �� Value True58      .a�59   *   ��  � ��
 �  ��6G   5:   '   5<      ._�5>      �� ��6$   �� *Value+5?      5@      5B      �� 5C      $��Create Problem��6   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6.   $��1��6_   $��3��6�   $��2q�6  ��6o   �� *CreateProblemCommand+# [ {�6�   �� *CurrentlySolving+# [ 6  �� 5D      $��Solve sorting problem��6   $ Depth3=�65   $��2��6�   $��3��6�   $��2q�6�   ��6f   �� *SortCommand+# [ 6�   5E      5G      5H      