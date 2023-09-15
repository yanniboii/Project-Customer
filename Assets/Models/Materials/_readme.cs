// the plant shaders are a bit convoluted sorry

//all the plants need their own individual material instance because of the thickness and AO map that need to be plugged in because of the way the fake subsurface scattering works (right click the PlantShader shader graph and do create > material)
//if you need thickness and AO maps push them to the github and i (bones) can make them for you or you can generate them yourself in substance painter