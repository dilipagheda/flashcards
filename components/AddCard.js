import React, { Component } from 'react';
import { StyleSheet, View, Text, TouchableOpacity, TextInput, Button } from 'react-native';
import { purple, white, red } from '../utils/colors';
import AppButton from './AppButton';

class AddCard extends Component {
	state = {
		value: ''
	};

	onChangeText = (value) => {
		this.setState({ value });
	};
	render() {
		return (
			<View style={styles.container}>
				<TextInput
					placeholder="Enter Question"
					style={styles.item}
					onChangeText={(text) => this.onChangeText(text)}
					value={this.state.value}
				/>

				<TextInput
					placeholder="Enter Answer"
					style={styles.item}
					onChangeText={(text) => this.onChangeText(text)}
					value={this.state.value}
				/>
				<AppButton title="Add Card" />
			</View>
		);
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		padding: 20,
		// backgroundColor: red,
		borderWidth: 1,
		justifyContent: 'flex-start'
	},
	item: {
		height: 40,
		borderColor: 'gray',
		borderWidth: 1,
		margin: 10,
		padding: 5,
		fontSize: 20
	}
});

export default AddCard;
