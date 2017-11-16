function test()
I = imread('mnist.png');
%16*16
N=size(I,1);
M=size(I,2);
n=(N/16);
m=(M/16);
total=n*m;
A=[];
num = 1;
i=0;j=0;
for i = 1:16:N
    for j = 1:16:M
        Block = I(i:i+15,j:j+15);
        A{num}=Block;      
        num=num+1;        
    end  
end
imshow(A{1})

%%for j = 1:total
 %%   test = A{j};
 %%   g=test(:);
  %%  ga=g';
 %%   ggc=9;
  %%  gg=[ga,ggc];   
 %%   B(j,:)=gg;
%%end


end

