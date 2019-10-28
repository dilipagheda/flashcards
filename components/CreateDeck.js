import React, { Component } from 'react';
import { StyleSheet, View, Text, TextInput } from 'react-native';
import AppButton from './AppButton';

class CreateDeck extends Component {
	state = {
		value: ''
	};
	onChangeText = (value) => {
		this.setState({ value });
	};
	render() {
		return (
			<View style={styles.container}>
				<Text style={styles.header}>What is the title of your new deck?</Text>

				<TextInput
					placeholder="Enter deck title"
					style={styles.item}
					onChangeText={(text) => this.onChangeText(text)}
					value={this.state.value}
				/>
				<AppButton title="Create Deck" />
			</View>
		);
	}
}
const styles = StyleSheet.create({
	container: {
		flex: 1,
		padding: 20,
		// backgroundColor: red,
		// borderWidth: 1,
		justifyContent: 'flex-start'
	},
	item: {
		height: 40,
		borderColor: 'gray',
		borderWidth: 1,
		margin: 10,
		padding: 5,
		fontSize: 20
	},
	header: {
		fontSize: 20,
		textAlign: 'center'
	}
});

export default CreateDeck;
