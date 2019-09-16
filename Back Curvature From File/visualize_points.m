pointsFiltered = csvread('points_filtered.txt');
points= csvread('points.txt');
spinePoints = csvread('spine_points.txt');

a = pointsFiltered(:,1);
b = pointsFiltered(:,2);
c = pointsFiltered(:,3);

a1 = points(:,1);
b1 = points(:,2);
c1 = points(:,3);

sA = sPoints(:,1);
sB = sPoints(:,2);

minB = min(sB);
maxB = max(sB);
% sAs = smoothdata(sA,'lowess');
% pointsA = minB:(maxB - minB) / 10000:maxB;
% splineP = spline(sA,sB,pointsA);
% minS = 
% scatter3(a,b,c);
title('Vizualization')

hold on
axis equal
scatter3(a,b,c, 25);
scatter(sA,sB, 50, 'green','filled');
scatter3(a1,b1,c1, 2, 'red');
% plot(sA,sB);
% plot(sA,sB); 
% plot(sAs,sB);
% scatter3(ar,br,cr, 2, 'blue');
hold off