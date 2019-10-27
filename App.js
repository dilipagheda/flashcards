import React, { Component } from 'react';
import { StyleSheet, View } from 'react-native';
import AppStatusBar from './components/AppStatusBar';

export default class App extends Component {
	static navigationOptions = {
		title: 'Home'
	};
	render() {
		return (
			<View style={{ flex: 1 }}>
				<AppStatusBar backgroundColor="#ff0000" barStyle="light-content" />
			</View>
		);
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		backgroundColor: '#fff',
		alignItems: 'center',
		justifyContent: 'center'
	}
});
