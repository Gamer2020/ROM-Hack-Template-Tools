#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define N 120

int main()
{
    int i=0;
    char nomi[N];
    int n=0;

    printf("Insert strings max lenght: ");
    scanf("%d", &n);

    FILE *o=fopen("output.txt", "w");
    if(o == NULL)
    {
        return(-1);
    }

    FILE *f=fopen("input.txt", "r");
    if(f == NULL)
    {
        return(-1);
    }


    while(fgets(nomi, N, f)!=NULL)
    {
        fprintf(o, ".byte %c_", nomi[i]);
        i++;

        while(nomi[i]!='\n'&&nomi[i]!='\0')
        {
            if(nomi[i]==' ')
            {
                fprintf(o, ", Space");
                i++;
            }
            else if(nomi[i]=='-')
            {
                fprintf(o, ", Dash");
                i++;
            }
            else if(nomi[i]==',')
            {
                fprintf(o, ", Comma");
                i++;
            }
            else if(nomi[i]=='!')
            {
                fprintf(o, ", Exclam");
                i++;
            }
            else if(nomi[i]=='?')
            {
                fprintf(o, ", Interro");
                i++;
            }
            else if(nomi[i]=='/')
            {
                fprintf(o, ", Slash");
                i++;
            }
            else if(nomi[i]==39)
            {
                fprintf(o, ", Apos");
                i++;
            }
            else if(nomi[i]==46)
            {
                fprintf(o, ", Dot");
                i++;
            }
            else if(nomi[i]=='2')
            {
                fprintf(o, ", 0xA3");
                i++;
            }
            else
            {
                fprintf(o, ", %c_", nomi[i]);
                i++;
            }
        }

        if(i<n)
        {
            fprintf(o, ", Termin");
            i++;
        }
        else
        {
            fprintf(o, ", Termin TOO MANY CHARACHTERS HERE");
            i++;
        }

        while(i<n)
        {
            fprintf(o, ", Space");
            i++;
        }
        fprintf(o, "\n");
        i=0;
    }

    fclose(f);
    fclose(o);
    return 0;
}
