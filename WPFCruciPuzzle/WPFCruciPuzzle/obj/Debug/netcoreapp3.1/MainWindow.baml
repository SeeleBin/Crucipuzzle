   M S B A M L   `   `   `  ����I  EWPFCruciPuzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFCruciPuzzleWPFCruciPuzzle  5   	       WPFCruciPuzzle.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPFCruciPuzzle     5   	     � Title$  Crucipuzzle WPF��5   	   $	��450��6!   $	��800��6.   .��5	      � $��434.04��6   $	��800��6   
����� � � ColumnDefinitions 5
   
   �� 5      $	��29* �6   �� 5      $
��771* �6   .+�5   
   � -   5         �Name$	 Tab��5      $	��320��6   $	��320��6)   $
��Left=�65   $	��Top=�6Q   $��	26,23,0,0q�6i   $��2��6|   �� 5   
   -   5         ��Name$ LetRimanenti��5      $��	Soluzione��6'   $��315,361,271,32q�6;   ${�False��6S   $��1��6�   �� 5   
   -   5        $ CercaParole��5      $��Cerca parola��6&   $��512,139,74,253q�6=   ${�False��6U   $��1��6�   �� 5   
   -   5         ��Name$ FinalSolution��5      $
��Wrap=�6+   $��0,361,511,27q�6?   $��10000��6U   $��1��6f   �� 5   
   -   5         ��Name$ FileName��5      $
��Left=�6$   $��
512,97,0,0q�6?    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��185��6    J� RenderTransformOrigin$ 0.517,-0.944&�6�   $��29��6�   $��15(�6�   $��tabellone.txt��6�   $��1��6�   �� 5   
   -   5        $ 
FileOpener��5      $��ApriFile��6%   $��512,43,74,362q�68   $��1��6h   �� 5   
   -   5         ��Name$ 	UserInput��5      $��Inserisci parola:��6#   $��407,205,272,203q�6?   $ 0.175,0.528&�6X   $��1��6|   �� 5   
   -   5        $ InserimentoUtente��5      $
 Wrap=�6-   $��512,205,74,205q�6A   ${�False��6Y   $��1��6k   5      5      