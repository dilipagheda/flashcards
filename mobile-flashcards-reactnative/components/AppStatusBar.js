import React, { Component } from 'react';
import { View, StatusBar } from 'react-native';
import Constants from 'expo-constants';

function AppStatusBar({ backgroundColor, ...props }) {
	return (
		<View style={{ backgroundColor, height: Constants.statusBarHeight }}>
			<StatusBar translucent backgroundColor={backgroundColor} {...props} />
		</View>
	);
}

export default AppStatusBar;
