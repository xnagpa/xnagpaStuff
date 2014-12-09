import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.io.*;


public class Main {

    static int ch=0;
    static int zn=0;
    static int scale=0;

    public static void main(String[] args) throws IOException {

        System.out.println("Enter digits like '10 5 2', type 'exit' when you finish ");

        BufferedReader buffer=new BufferedReader(new InputStreamReader(System.in));
        String usersInput;
        String exitString="";
        while(exitString.compareTo("exit")!=0)
        {
            usersInput=buffer.readLine();
            if (usersInput.compareToIgnoreCase("exit")!=0)
            {
                String [] tempArrayOfStrings=  usersInput.split(" ");
                try {
                    ch= Integer.parseInt(tempArrayOfStrings[0]);
                    zn= Integer.parseInt(tempArrayOfStrings[1]);
                    scale= Integer.parseInt(tempArrayOfStrings[2]);
                }
                catch(Exception exc)
                {
                    System.out.println("Looks like you typed smth wrong. Type integer divided by space and then 'exit'");
                }


                StringBuilder sb = new StringBuilder();
                if(zn!=0)
                {

                    //I wanna know if I could get an integer part of the fraction
                    if (ch>zn)
                    {
                      int integerPart=ch/zn;
                      int newCh=ch%zn;
                      sb.append(translateIntegerPart(integerPart, scale));
                      if(newCh!=0)
                      {
                         sb.append(translateFractionPart(newCh, zn, scale));
                      }

                    }
                    else
                    {
                        int newCh=ch%zn;
                        sb.append("0");
                        sb.append(translateFractionPart(newCh, zn, scale));
                    }

                    System.out.println(sb.toString());
                }
                else
                {
                    System.out.println("Btw,don't divide by zero!It's against the law!");
                }
            }
            else
            {
                exitString="exit";
                buffer.close();
            }
        }
    }


    public static String translateFractionPart(int x, int y, int scaleOfNotation)
    {
        ArrayList<Integer> resultArray = new ArrayList();
        ArrayList<Integer> remainderArray = new ArrayList();
        StringBuilder sb = new StringBuilder();

        int remainder;
        int integerDivision;
        int periodPointer;

          while(remainderArray.indexOf(x%y)==-1&&x%y!=0)
            {
                x%=y;
                remainder=x;
                x*=scaleOfNotation;
                integerDivision=x/y;

                if (remainderArray.indexOf(remainder)==-1)
                {
                    remainderArray.add(remainder);
                    resultArray.add(integerDivision);

                }
            }
        periodPointer = remainderArray.indexOf(x%y);

        //Preparing nice output
        sb.append(".");
        for (int j=0;j<resultArray.size();j++)
        {
            if (j==periodPointer)
            {
                sb.append("(");
            }
            Integer symbol = resultArray.get(j);
            if(symbol >9)
            {//Magic numbers are: 65 - 'A', 48-'0'
                sb.append((char)(symbol -10+65));
            }
            else
            {
             sb.append((char)(symbol+48));
            }
            if (j==resultArray.size()-1 && periodPointer!=-1)
            {
                sb.append(")");
            }
        }

        return  sb.toString();


    }


    // translation for the integer part
    public static String translateIntegerPart(int x, int scaleOfNotation)
    {
        ArrayList<Integer> resultArray = new ArrayList();
        StringBuilder sb = new StringBuilder();
        int i=0;
        int temp =x;


        while(temp/scaleOfNotation!=0)
        {
            resultArray.add(temp%scaleOfNotation);
            temp=temp/scaleOfNotation;
            i++;

        }
        resultArray.add(temp%scaleOfNotation);

        //Preparing nice output
        for (int j=resultArray.size();j>0;j--)
        {
            Integer symbol = resultArray.get(j-1);
            if(symbol >9 && scaleOfNotation>10)
            {//Magic numbers are: 65 - 'A', 48-'0'
                sb.append((char)(symbol -10+65));
            }
            else
            {
                sb.append((char)(symbol+48));
            }
        }
        return  sb.toString();

    }
}



