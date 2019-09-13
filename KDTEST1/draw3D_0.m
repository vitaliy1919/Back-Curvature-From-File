X = csvread('writeNewFiltered.txt');
X1= csvread('writeNew.txt');
XRotated= csvread('writeRotated.txt');
sPoints = csvread('spinePoints.txt');

a = X(:,1);
b = X(:,2);
c = X(:,3);
a1 = X1(:,1);
b1 = X1(:,2);
c1 = X1(:,3);
ar = XRotated(:,1);
br = XRotated(:,2);
cr = XRotated(:,3);

sA = sPoints(:,1);
sB = sPoints(:,2);

minB = min(sB);
maxB = max(sB);
% sAs = smoothdata(sA,'lowess');
% pointsA = minB:(maxB - minB) / 10000:maxB;
% splineP = spline(sA,sB,pointsA);
% minS = 
% scatter3(a,b,c);
title('Combine Plots')

hold on
axis equal
scatter3(a,b,c, 25);
scatter(sA,sB, 50, 'green','filled');
% plot(sA,sB);
plot(sA,sB); 
% plot(sAs,sB);
scatter3(a1,b1,c1, 2, 'red');
% scatter3(ar,br,cr, 2, 'blue');
hold off