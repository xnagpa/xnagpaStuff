/* package whatever; // don't place package name! */

import java.util.*;
import java.lang.*;
import java.io.*;


/* Name of the class has to be "Main" only if the class is public. */
class Main
{
    public static void main (String[] args) throws java.lang.Exception
    {
        BufferedReader buffer=new BufferedReader(new InputStreamReader(System.in));
        System.out.println("Enter the first array of N elements(separator is 'space'): ");
        int a[] = toIntArray(buffer.readLine());
        System.out.println("Enter the second array of N elements(separator is 'space'): ");
        int [] b = toIntArray(buffer.readLine());
       // int [] a = {1,2,3,4};
        //int [] b = {1,4,5,6};

        ArrayList<Integer> c = merge(a,b);
        System.out.println("Median is: "+findMedian(c));

    }

    static int[] toIntArray(String s)
    {
         String [] tempStringArray= s.split(" ");
        int [] tempIntArray = new int[tempStringArray.length];

        for (int i =0; i<tempIntArray.length;i++)
        {
            tempIntArray[i]= Integer.parseInt(tempStringArray[i]);
        }

        return tempIntArray;
    }

    public static double findMedian(ArrayList<Integer> a )
    {
        double mediana=0;

        if (a.size()%2==0)
        {

            int firstElement=a.size()/2-1;
            int secondElement=firstElement+1;
            mediana= (a.get(firstElement)+ a.get(secondElement))/2.0;
        }
        else
        {
            //I just leave it there
            mediana= a.get(a.size()/2);
        }
        return mediana;
    }

    public static ArrayList<Integer> merge(int[] a, int[] b)
    {
        ArrayList<Integer> c = new ArrayList();
        int i=0; int j=0;

        while(c.size()!=a.length+b.length)
        {
            if(a[i]<b[j])
            {
                c.add(a[i]);
                //add all the elements left in the other array
                if (i+1==a.length)
                {
                    while(j<b.length)
                    {
                        c.add(b[j]);
                        j++;
                    }
                }
                else
                    i++;

            }
            else
            {
                c.add(b[j]);
                //add all the elements left in the other array
                if (j+1==b.length)
                {

                    while(i<a.length)
                    {
                        c.add(a[i]);
                        i++;
                    }
                }
                else
                    j++;

            }

        }

        return c;
    }
}