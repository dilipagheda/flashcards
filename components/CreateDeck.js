import React, { Component } from 'react';
import { StyleSheet, View, Text, TextInput } from 'react-native';
import AppButton from './AppButton';
import { connect } from 'react-redux';
import { addDeck } from '../actions';
import { red } from '../utils/colors';
import ErrorMsg from './ErrorMsg';

class CreateDeck extends Component {
	state = {
		value: '',
		error: ''
	};
	onChangeText = (value) => {
		this.setState({ value });
	};
	onPress = () => {
		if (this.state.value.length === 0) {
			this.setState({ error: 'Please enter deck name!' });
			return;
		}
		if (Object.keys(this.props.data).includes(this.state.value)) {
			this.setState({ error: 'Deck already exists with same name!' });
			return;
		}

		this.props.dispatch(addDeck(this.state.value));
		this.setState({ value: '', error: '' });
		this.props.navigation.navigate('Decks');
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
				<ErrorMsg value={this.state.error} />
				<AppButton title="Create Deck" onPress={this.onPress} />
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
	},
	error: {
		marginLeft: 10,
		color: red
	}
});

function mapStateToProps(state) {
	return { data: state };
}

export default connect(mapStateToProps)(CreateDeck);
