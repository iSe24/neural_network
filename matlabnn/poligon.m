function map = poligon()
I = imread('a2s.bmp');  %='a2s.bmp'
g=I(:);
ga=g';
c=[];
A = [];
%c=['[',int2str(ga(1))];
for i=1:256
    c=[c,(ga(i))];
    A(i)=ga(i);
end
%c=[c,']'];
map = A;
end