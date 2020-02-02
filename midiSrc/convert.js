/// Convert midi to Notes data ///

// 1. visit http://flashmusicgames.com/midi/mid2txt.php and upload mid file (ex: RepaTiti_A_Mid.mid)
// 2. copy lines like "23040 On ch=1 n=82 v=92" as notes data
// 3. paste into `data` variable below
// 4. go to https://codepen.io/pen
// 5. paste <pre id='result'></pre> into html
// 6. copy this entire js file into javascript
// 7. open Assets/Levels/Level_1/Score_2.asset (or other asset file, they are just yaml files)
// 8. copy result from codepen into .asset yaml file after "Notes:" line
// 9. save .asset yaml and go to Unity to see if successfully changed

// RepaTiti A middle track (from RepaTiti_A_Mid.mid, for Assets/Levels/Level_1/Score_2.asset)
const data = `7200 On ch=1 n=75 v=80
7680 Off ch=1 n=75 v=64
8640 On ch=1 n=82 v=80
9360 On ch=1 n=77 v=80
10080 Off ch=1 n=77 v=64
10080 Off ch=1 n=82 v=64
10080 On ch=1 n=79 v=80
11040 Off ch=1 n=79 v=64
11520 On ch=1 n=82 v=80
12240 Off ch=1 n=82 v=64
12960 On ch=1 n=82 v=80
13440 Off ch=1 n=82 v=64
13440 On ch=1 n=80 v=80
13920 Off ch=1 n=80 v=64
13920 On ch=1 n=79 v=80
14400 Off ch=1 n=79 v=64
14400 On ch=1 n=77 v=80
15120 Off ch=1 n=77 v=64
15840 On ch=1 n=79 v=80
17280 Off ch=1 n=79 v=64
17280 On ch=1 n=75 v=80
18000 Off ch=1 n=75 v=64
18720 On ch=1 n=75 v=80
19200 Off ch=1 n=75 v=64
19200 On ch=1 n=77 v=80
19680 Off ch=1 n=77 v=64
19680 On ch=1 n=79 v=80
20160 Off ch=1 n=79 v=64
20160 On ch=1 n=77 v=80
20880 Off ch=1 n=77 v=64
21600 On ch=1 n=79 v=80
23040 Off ch=1 n=79 v=64
27360 On ch=1 n=79 v=80
28800 Off ch=1 n=79 v=64
28800 On ch=1 n=75 v=80
29520 Off ch=1 n=75 v=64
29520 On ch=1 n=75 v=80
30240 Off ch=1 n=75 v=64
30240 On ch=1 n=75 v=80
30720 Off ch=1 n=75 v=64
31680 On ch=1 n=82 v=80
32400 On ch=1 n=77 v=80
33120 Off ch=1 n=77 v=64
33120 Off ch=1 n=82 v=64
33120 On ch=1 n=79 v=80
34080 Off ch=1 n=79 v=64
34560 On ch=1 n=82 v=80
35280 Off ch=1 n=82 v=64
35280 On ch=1 n=82 v=80
35760 Off ch=1 n=82 v=64
36000 On ch=1 n=82 v=80
36480 Off ch=1 n=82 v=64
37440 On ch=1 n=77 v=80
38160 Off ch=1 n=77 v=64
38160 On ch=1 n=77 v=80
38640 Off ch=1 n=77 v=64
38880 On ch=1 n=79 v=80
40320 Off ch=1 n=79 v=64
40320 On ch=1 n=75 v=80
41040 Off ch=1 n=75 v=64
41040 On ch=1 n=75 v=80
41760 Off ch=1 n=75 v=64
41760 On ch=1 n=75 v=80
42240 Off ch=1 n=75 v=64
43200 On ch=1 n=77 v=80
43920 Off ch=1 n=77 v=64
43920 On ch=1 n=77 v=80
44640 Off ch=1 n=77 v=64
44640 On ch=1 n=79 v=80
45120 On ch=1 n=77 v=80
45600 On ch=1 n=75 v=80
46080 Off ch=1 n=75 v=64
46080 Off ch=1 n=77 v=64
46080 Off ch=1 n=79 v=64
49920 On ch=1 n=77 v=80
50400 Off ch=1 n=77 v=64
50400 On ch=1 n=79 v=80
51840 Off ch=1 n=79 v=64
51840 On ch=1 n=75 v=80
52560 Off ch=1 n=75 v=64
53280 On ch=1 n=75 v=80
53760 Off ch=1 n=75 v=64
53760 On ch=1 n=77 v=80
54240 Off ch=1 n=77 v=64
54240 On ch=1 n=79 v=80
54720 Off ch=1 n=79 v=64
54720 On ch=1 n=77 v=80
55440 Off ch=1 n=77 v=64
55440 On ch=1 n=77 v=80
56160 Off ch=1 n=77 v=64
56160 On ch=1 n=75 v=80
57600 Off ch=1 n=75 v=64
57600 On ch=1 n=79 v=80
57840 Off ch=1 n=79 v=64
58080 On ch=1 n=79 v=80
58320 Off ch=1 n=79 v=64
58560 On ch=1 n=79 v=80
59040 Off ch=1 n=79 v=64
59040 On ch=1 n=82 v=80
59520 Off ch=1 n=82 v=64
60480 On ch=1 n=79 v=80
60720 Off ch=1 n=79 v=64
60960 On ch=1 n=79 v=80
61200 Off ch=1 n=79 v=64
61440 On ch=1 n=79 v=80
61920 Off ch=1 n=79 v=64
61920 On ch=1 n=86 v=80
62400 Off ch=1 n=86 v=64
63360 On ch=1 n=79 v=80
63600 Off ch=1 n=79 v=64
63840 On ch=1 n=79 v=80
64080 Off ch=1 n=79 v=64
64320 On ch=1 n=79 v=80
64800 Off ch=1 n=79 v=64
64800 On ch=1 n=82 v=80
65280 Off ch=1 n=82 v=64
66240 On ch=1 n=82 v=80
66480 Off ch=1 n=82 v=64
66720 On ch=1 n=82 v=80
66960 Off ch=1 n=82 v=64
67200 On ch=1 n=82 v=80
67680 Off ch=1 n=82 v=64
67680 On ch=1 n=86 v=80
68160 Off ch=1 n=86 v=64
69120 On ch=1 n=79 v=80
69360 Off ch=1 n=79 v=64
69600 On ch=1 n=79 v=80
69840 Off ch=1 n=79 v=64
70080 On ch=1 n=79 v=80
70560 Off ch=1 n=79 v=64
70560 On ch=1 n=82 v=80
71040 Off ch=1 n=82 v=64
72000 On ch=1 n=79 v=80
72240 Off ch=1 n=79 v=64
72480 On ch=1 n=79 v=80
72720 Off ch=1 n=79 v=64
72960 On ch=1 n=79 v=80
73440 Off ch=1 n=79 v=64
73440 On ch=1 n=86 v=80
73920 Off ch=1 n=86 v=64
74880 On ch=1 n=79 v=80
75120 Off ch=1 n=79 v=64
75360 On ch=1 n=79 v=80
75600 Off ch=1 n=79 v=64
75840 On ch=1 n=79 v=80
76320 Off ch=1 n=79 v=64
76320 On ch=1 n=82 v=80
76800 Off ch=1 n=82 v=64
77760 On ch=1 n=82 v=80
78000 Off ch=1 n=82 v=64
78240 On ch=1 n=82 v=80
78480 Off ch=1 n=82 v=64
78720 On ch=1 n=82 v=80
79200 Off ch=1 n=82 v=64
79200 On ch=1 n=79 v=80
79680 Off ch=1 n=79 v=64
84960 On ch=1 n=79 v=80
86400 Off ch=1 n=79 v=64
86400 On ch=1 n=75 v=80
87120 Off ch=1 n=75 v=64
87120 On ch=1 n=75 v=80
87840 Off ch=1 n=75 v=64
87840 On ch=1 n=75 v=80
88320 Off ch=1 n=75 v=64
89280 On ch=1 n=82 v=80
90000 On ch=1 n=77 v=80
90720 Off ch=1 n=77 v=64
90720 Off ch=1 n=82 v=64
90720 On ch=1 n=79 v=80
91680 Off ch=1 n=79 v=64
92160 On ch=1 n=82 v=80
92880 Off ch=1 n=82 v=64
92880 On ch=1 n=82 v=80
93360 Off ch=1 n=82 v=64
93600 On ch=1 n=82 v=80
94080 Off ch=1 n=82 v=64
95040 On ch=1 n=77 v=80
95760 Off ch=1 n=77 v=64
95760 On ch=1 n=77 v=80
96240 Off ch=1 n=77 v=64
96480 On ch=1 n=79 v=80
97920 Off ch=1 n=79 v=64
97920 On ch=1 n=75 v=80
98640 Off ch=1 n=75 v=64
98640 On ch=1 n=75 v=80
99360 Off ch=1 n=75 v=64
99360 On ch=1 n=75 v=80
99840 Off ch=1 n=75 v=64
100800 On ch=1 n=77 v=80
101520 Off ch=1 n=77 v=64
101520 On ch=1 n=77 v=80
102240 Off ch=1 n=77 v=64
102240 On ch=1 n=79 v=80
102720 On ch=1 n=77 v=80
103200 On ch=1 n=75 v=80
103680 Off ch=1 n=75 v=64
103680 Off ch=1 n=77 v=64
103680 Off ch=1 n=79 v=64
107520 On ch=1 n=77 v=80
108000 Off ch=1 n=77 v=64
108000 On ch=1 n=79 v=80
109440 Off ch=1 n=79 v=64
109440 On ch=1 n=75 v=80
110160 Off ch=1 n=75 v=64
110880 On ch=1 n=75 v=80
111360 Off ch=1 n=75 v=64
111360 On ch=1 n=77 v=80
111840 Off ch=1 n=77 v=64
111840 On ch=1 n=79 v=80
112320 Off ch=1 n=79 v=64
112320 On ch=1 n=77 v=80
113040 Off ch=1 n=77 v=64
113040 On ch=1 n=77 v=80
113760 Off ch=1 n=77 v=64
113760 On ch=1 n=75 v=80
115200 On ch=1 n=87 v=80
115680 Off ch=1 n=87 v=64
116160 On ch=1 n=87 v=80
116400 Off ch=1 n=87 v=64
116640 Off ch=1 n=75 v=64
116640 On ch=1 n=91 v=80
117120 Off ch=1 n=91 v=64
117600 On ch=1 n=87 v=80
117840 Off ch=1 n=87 v=64
118080 On ch=1 n=87 v=80
118560 Off ch=1 n=87 v=64
119040 On ch=1 n=87 v=80
119280 Off ch=1 n=87 v=64
119520 On ch=1 n=94 v=80
120000 Off ch=1 n=94 v=64
120480 On ch=1 n=91 v=80
120720 Off ch=1 n=91 v=64
120960 On ch=1 n=87 v=80
121440 Off ch=1 n=87 v=64
121920 On ch=1 n=87 v=80
122160 Off ch=1 n=87 v=64
122400 On ch=1 n=91 v=80
122880 Off ch=1 n=91 v=64
123360 On ch=1 n=87 v=80
123600 Off ch=1 n=87 v=64
123840 On ch=1 n=87 v=80
124320 Off ch=1 n=87 v=64
124320 On ch=1 n=86 v=80
124800 Off ch=1 n=86 v=64
124800 On ch=1 n=87 v=80
125040 Off ch=1 n=87 v=64
125280 On ch=1 n=87 v=80
129600 Off ch=1 n=87 v=64`

const result = data.split('\n').map(line => {
  const fields = line.split(' ')
  return {
    t: fields[0],
    on: fields[1].toLowerCase() === 'on',
    ...(Object.fromEntries(fields.slice(2).map(f => f.split('=')))),
    // ori: line,
  }
}).filter(note => note.on)

console.log({ result })
// document.getElementById('result').textContent = JSON.stringify(result)
document.getElementById('result').textContent = result.map(note => {
  return (
`  - Time: ${note.t / 1163 + 0.125}
    Pitch: ${note.n}`
  )
}).join('\n')